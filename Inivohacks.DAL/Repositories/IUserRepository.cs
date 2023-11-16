using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.DAL.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<bool> AddUserAsync(User user);
        public Task<User> GetUsebyUserIdAsync(int userID);
    }
}
