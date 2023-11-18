using Inivohacks.BL.DTOs;
using Inivohacks.BL.Helper;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;
using System.Security;

namespace Inivohacks.BL.BLServices
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<bool> CreatePermissionAsync(PermissionDto dto)
        {
            if (dto == null)
            {
                return false;
            }
            try
            {
                bool success = await _permissionRepository.AddPermissionAsync(dto.TransformAPItoDAL());
                return success;
            }
            catch
            {
                return false;
            }
        }

        public async Task<PermissionDto> GetPermissionByIdAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new ArgumentNullException(nameof(id));
                }

                Permission result = await _permissionRepository.GetPermissionbyPermissionIdAsync(id);
                if (result == null)
                {
                    return null;
                }

                return result.TransformDALtoAPI();
            }
            catch
            {
                return null;
            }


        }

        public async IAsyncEnumerable<PermissionDto> GetAllPermissionsAsync()
        {
            IAsyncEnumerable<Permission> result = _permissionRepository.GetAllPermissionAsync();


            await foreach (var m in result)
            {
                yield return m.TransformDALtoAPI();
            }
        }
    }
}