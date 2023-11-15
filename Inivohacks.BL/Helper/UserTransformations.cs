using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;

namespace Inivohacks.BL.Helper
{
    public static class UserTransformations
    {
        public static UserDto TransformDALtoAPI(this User user)
        {
            if (user == null)
                return null;

            var item = new UserDto()
            {
                Username = user.Username,
                Password = user.Password,
                ManufacturerID = user.ManufacturerID,
                LoginDisabled = user.LoginDisabled
            };

            return item;
        }

        public static User TransformAPItoDAL(this UserDto user)
        {
            if (user == null)
                return null;

            var item = new User()
            {
                Username = user.Username,
                Password = user.Password,
                ManufacturerID = user.ManufacturerID,
                LoginDisabled = user.LoginDisabled

            };

            return item;
        }
    }
}
