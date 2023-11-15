using Inivohacks.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.BLServices
{
    public interface IUserService
    {
        public Task<bool> CreateUserAsyncAsync(UserDto user);
    }
}
