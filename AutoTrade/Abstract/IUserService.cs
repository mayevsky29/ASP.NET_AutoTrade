using AutoTrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrade.Abstract
{
    public interface IUserService
    {
        public Task<string> CreateUser(RegisterViewModel model);
    }
}
