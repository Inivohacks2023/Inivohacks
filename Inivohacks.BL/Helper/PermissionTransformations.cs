using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;

namespace Inivohacks.BL.Helper
{
    public static class PermissionTransformations
    {
        public static PermissionDto TransformDALtoAPI(this Permission p)
        {
            if (p == null)
                return null;

            var item = new PermissionDto()
            {
               PermissionCode = p.PermissionCode,
               PermissionDescription= p.PermissionDescription,
            };

            return item;
        }

        public static Permission TransformAPItoDAL(this PermissionDto p)
        {
            if (p == null)
                return null;

            var item = new Permission()
            {
                PermissionDescription = p.PermissionDescription,
                PermissionCode= p.PermissionCode,
                PermissionId = p.PermissionId,
            };

            return item;
        }
    }
}
