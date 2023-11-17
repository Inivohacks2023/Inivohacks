using Inivohacks.DAL.Models;

namespace Inivohacks.DAL.Repositories
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        public Task<bool> AddPermissionAsync(Permission product);
        public Task<Permission> GetPermissionbyPermissionIdAsync(int productId);
        public IAsyncEnumerable<Permission> GetAllPermissionAsync();
    }
}
