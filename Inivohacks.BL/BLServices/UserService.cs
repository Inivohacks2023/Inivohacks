using Inivohacks.BL.DTOs;
using Inivohacks.BL.Helper;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.BLServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<bool> CreateUserAsyncAsync(UserDto user)
        {
            bool status = false;
            if (user == null)
            {
                status = false;
            }
            try
            {
                await userRepository.AddUserAsync(user.TransformAPItoDAL());
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }
    }
}
