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

    }
}
