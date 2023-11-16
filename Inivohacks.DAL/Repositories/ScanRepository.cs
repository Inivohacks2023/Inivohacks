using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.DAL.Repositories
{
    public class ScanRepository: RepositoryBase<Scan>, IScanRepository
    {
        private readonly DatabaseContext _dbContext;
        public ScanRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

     
    }
}
