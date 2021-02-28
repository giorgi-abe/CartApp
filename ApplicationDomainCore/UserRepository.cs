using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using ApplicationDomainEntity.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomainCore
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db = default;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> CreateAsync(User item)
        {
            await _db.Users.AddAsync(item);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var item = await ReadByIdAsync(id);
            _db.Users.Remove(item);
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> ReadAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> ReadByIdAsync(string id)
        {
            return await _db.Users.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<bool> UpdateAsync(string id, User item)
        {
            item.Id = id;
            _db.Users.Update(item);
            return await SaveChangesAsync();
        }
        private async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await _db.SaveChangesAsync() >= 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
