using AutoTrade.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrade.Controllers
{
    public class AccountControler : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AccountController : ControllerBase
        {
            [HttpPost]
            [Route("register")]
            public IActionResult Register([FromBody] RegisterViewModel model)
            {
                //return BadRequest(new
                //{
                //    message = "Такий користувач уже є!"
                //});
                return Ok();
            }
        }
    }
}
