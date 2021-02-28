using ApplicationDatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomainCore.Abstraction
{
    public interface IUserRepository
    {
        Task<bool> CreateAsync(User item);
        Task<IEnumerable<User>> ReadAsync();
        Task<User> ReadByIdAsync(string id);
        Task<bool> UpdateAsync(string id, User item);
        Task<bool> DeleteAsync(string id);
    }
}
