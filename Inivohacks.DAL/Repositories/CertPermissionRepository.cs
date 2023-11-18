using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.DAL.Repositories
{
    public class CertPermissionRepository: RepositoryBase<CertPermission>, ICertPermission
    {
        private readonly DatabaseContext _dbContext;
        public CertPermissionRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

       
    }
}
