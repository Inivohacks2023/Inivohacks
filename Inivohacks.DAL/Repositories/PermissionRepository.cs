using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.DAL.Repositories
{
    public class PermissionRepository: RepositoryBase<Permission>, IPermissionRepository
    {
        private readonly DatabaseContext _dbContext;
        public PermissionRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> AddPermissionAsync(Permission permission)
        {
            await AddAsync(permission);
            return true;
        }

        public async Task<Permission> GetPermissionbyPermissionIdAsync(int id)
        {
            return Search(a => a.PermissionId == id).FirstOrDefault();
        }
        public async IAsyncEnumerable<Permission> GetAllPermissionAsync()
        {
            foreach (var plist in _dbContext.Permissions.ToList())
            {
                yield return plist;
            }
        }
    }
}
