using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.DAL.Repositories
{
    public class CertificateRepository: RepositoryBase<Certificate>, ICertificateRepository
    {
        private readonly DatabaseContext _dbContext;
        public CertificateRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<int> AddCertPermissionAsync(Certificate certificate)
        {
            await AddAsync(certificate);
           var cerID= _dbContext.Certificates.OrderByDescending(x => x.CertificateID).Select(y => y.CertificateID);
            return Convert.ToInt32(cerID);
        }

        public IAsyncEnumerable<Certificate> GetAllCertificateAsync(int productID)
        {
            return Search(a => a.ProductID == productID).AsAsyncEnumerable();
        }
    }
}
