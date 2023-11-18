using Inivohacks.BL.DTOs;

namespace Inivohacks.BL.BLServices
{
    public interface IPermissionService
    {
        public Task<bool> CreatePermissionAsync(PermissionDto dto);
        public Task<PermissionDto> GetPermissionByIdAsync(int id);
        public IAsyncEnumerable<PermissionDto> GetAllPermissionsAsync();
    }
}