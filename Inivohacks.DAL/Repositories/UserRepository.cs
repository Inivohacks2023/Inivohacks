﻿using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly DatabaseContext _dbContext;
        public UserRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            try { 
                var result = await AddAsync(user);
                return true;
            } catch
            {
                return false;
            }
        }

        public async Task<User> GetUserbyUserIdAsync(int id)
        {
            try { 
                User user = await _dbContext.Users.FindAsync(id) ?? new User();
                return user;
            }
            catch (Exception ex)
            {
                return new User();
            }
        }
    }
}
