using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrade.Models
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public IFormFile Photo { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AccountError
    {
        public AccountError()
        {
            Errors = new AccountErrorItem();
        }
        public AccountError(string message)
        {
            Errors = new AccountErrorItem();
            Errors.Invalid.Add(message);
        }
        public AccountErrorItem Errors { get; set; }
    }

    public class AccountErrorItem
    {
        public AccountErrorItem()
        {
            Invalid = new List<string>();
        }
        public List<string> Invalid { get; set; }
    }
}
