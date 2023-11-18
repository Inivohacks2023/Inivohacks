using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

        public string GetPermissionNamebyID(int certID)
        {
           int pId = Search(a => a.CertificateID == certID).Select(x => x.PermissionID).FirstOrDefault();
            return _dbContext.Permissions.Where(x => x.PermissionId == pId).Select(x => x.PermissionCode).FirstOrDefault();
        }

    }
}
