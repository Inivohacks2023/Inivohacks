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
        public async Task<bool> CreateUserAsync(UserDto user)
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

        public async Task<UserDto> GetUserByIDAsync(int userID)
        {
            if (userID == 0)
            {
                throw new ArgumentNullException(nameof(userID));
            }

            User user = await userRepository.GetUsebyUserIdAsync(userID);
            if (user == null)
            {
                return null;
            }

            return user.TransformDALtoAPI();
        }
    }
}
