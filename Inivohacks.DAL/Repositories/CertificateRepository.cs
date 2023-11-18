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
        public async Task<Certificate> AddCertPermissionAsync(Certificate certificate)
        {
           var cert = await AddAsync(certificate);
           return cert;
        }

        public IAsyncEnumerable<Certificate> GetAllCertificateAsync(int productID)
        {
            throw new NotImplementedException();
        }

        public async Task<Certificate> GetCertificateByTokenAsync(string token)
        {
            try
            {
                return Search(a => a.Token.Equals(token)).FirstOrDefault();
            }
            catch {
                return null;
            }
        }
    }
}
