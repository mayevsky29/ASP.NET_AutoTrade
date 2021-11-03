using AutoMapper;
using AutoTrade.Abstract;
using AutoTrade.Constants;
using AutoTrade.Exceptions;
using AutoTrade.Models;
using AutoTrade.Services;
using Data.AutoTrade.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrade.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtTokenService _tokenService;

        public AccountController(IUserService userService, UserManager<AppUser> userManager,
            IJwtTokenService tokenService)
        {
            _userService = userService;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            try
            {
                string token = await _userService.CreateUser(model);
                return Ok(
                    new { token }
               );
            }

            catch (AccountException aex)
            {
                return BadRequest(aex.AccountError);
            }
            catch 
            {
                return BadRequest(new AccountError("Щось пішло не так! "));
            }


        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    string token = _tokenService.CreateToken(user);
                    return Ok(
                        new { token }
                    );
                }
                else
                {

                    var exc = new AccountError();
                    exc.Errors.Invalid.Add("Пароль не вірний!");
                    throw new AccountException(exc);
                }
            }
            catch (AccountException aex)
            {
                return BadRequest(aex.AccountError);
            }
            catch
            {
                return BadRequest(new AccountError("Щось пішло не так!"));
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteUser([FromBody] int id)
        {
            return await Task.Run(() => {
                IActionResult result = null;
                var user = _userManager.FindByIdAsync(id.ToString()).Result;
                if (user != null)
                {
                    var resultDelete = _userManager.DeleteAsync(user).Result;
                    if (resultDelete.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(user.Photo))
                        {
                            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                                "images", user.Photo);
                            if (System.IO.File.Exists(filePath))
                                System.IO.File.Delete(filePath);
                        }
                        result = Ok();
                    }
                    else
                    {
                        var accountError = new AccountError();
                        foreach (var error in resultDelete.Errors)
                        {
                            accountError.Errors.Invalid.Add(error.Description);
                        }
                        result = BadRequest(accountError);
                    }

                }
                else
                {
                    var accountError = new AccountError();
                    accountError.Errors.Invalid.Add("Такого користувача нема");

                    result = BadRequest(accountError);
                }
                return result;
            });
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> EditUser([FromForm] EditViewModel model)
        {
            IActionResult result = null;
            var user = _userManager.FindByIdAsync(model.Id.ToString()).Result;
            if (user != null)
            {
                user.FirstName = model.Firstname;
                user.SecondName = model.Secondname;
                user.Phone = model.Phone;
                if (_userManager.FindByEmailAsync(model.Email).Result != null && user.Email != model.Email)
                {
                    var accountError = new AccountError();
                    accountError.Errors.Invalid.Add("Така пошта вже є");
                    return BadRequest(accountError);
                }
                user.Email = model.Email;
                user.UserName = model.Email;

                if (model.Image != null)
                {
                    string dir = Path.Combine(Directory.GetCurrentDirectory(), "images");
                    if (!string.IsNullOrEmpty(user.Photo))
                    {
                        string fullPath = Path.Combine(dir, user.Photo);
                        if (System.IO.File.Exists(fullPath))
                            System.IO.File.Delete(fullPath);
                    }

                    string fileName = Path.GetRandomFileName() + Path.GetExtension(model.Image.FileName);
                    string fullPathNew = Path.Combine(dir, fileName);
                    using (var stream = System.IO.File.Create(fullPathNew))
                    {
                        user.Photo = fileName;
                        model.Image.CopyTo(stream);
                    }
                }

                if (!string.IsNullOrEmpty(model.OldPassword) && !string.IsNullOrEmpty(model.Password))
                {
                    var changePassword = _userManager
                        .ChangePasswordAsync(user, model.OldPassword, model.Password).Result;

                    if (!changePassword.Succeeded)
                    {
                        var accountError = new AccountError();
                        accountError.Errors.Invalid.Add("Пароль не вірний");
                        return BadRequest(accountError);
                    }
                }

                var resultUpdate = await _userManager.UpdateAsync(user);
                if (resultUpdate.Succeeded)
                {
                    result = Ok("Update success");
                }
                else
                {
                    var accountError = new AccountError();
                    foreach (var error in resultUpdate.Errors)
                    {
                        accountError.Errors.Invalid.Add(error.Description);
                    }
                    result = BadRequest(accountError);
                }
            }
            else
            {
                var accountError = new AccountError();
                accountError.Errors.Invalid.Add("Користувача не існує");

                result = BadRequest(accountError);
            }
            return result;
        }

        [HttpPost]
        [Route("get")]
        public IActionResult GetUsers()
        {
            return Ok(new
            {
                users =
                _userManager.Users.Select(x => new
                {
                    Id = x.Id,
                    firstname = x.FirstName,
                    secondname = x.SecondName,
                    phone = x.Phone,
                    email = x.Email,
                    image = x.Photo
                }).ToList()
            });
        }

    }
}
