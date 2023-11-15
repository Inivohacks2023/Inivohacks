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
                bool success = await userRepository.AddUserAsync(user.TransformAPItoDAL());
                return success;
            }
            catch
            {
                return false;
            }
        }

        public async Task<UserDto> GetUserByIDAsync(int userId)
        {
            try
            {
                if (userId == 0)
                {
                    throw new ArgumentNullException(nameof(userId));
                }

                User user = await userRepository.GetUserbyUserIdAsync(userId);
                if (user == null)
                {
                    return null;
                }

                return user.TransformDALtoAPI();
            }
            catch {
                return null;
            }

            
        }
    }
}
