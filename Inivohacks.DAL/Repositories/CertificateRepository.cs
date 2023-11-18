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

        public async IAsyncEnumerable<Certificate> GetAllCertificateAsync(int productID)
        {
            foreach (var cert in _dbContext.Certificates.Where(x => x.ProductID == productID).ToList())
            {
                yield return cert;
            }
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

        public bool RevokeCertificate(string token)
        {
            try
            {
                Certificate cert = Search(a => string.Equals(a.Token, token)).FirstOrDefault();
                if (cert != null)
                {
                    cert.InUse = false;
                    UpdateAsync(cert);
                    return true;
                }

                return false;
            }
            catch { return false; }

        }
    }
}
