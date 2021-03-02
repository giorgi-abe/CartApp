using ApplicationDatabaseModels;
using ApplicationDomainCore.Abstraction;
using ApplicationDomainEntity.Db;
using ApplicationDtos;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager = default;
        private readonly SignInManager<User> _signInManager = default;
        public UserRepository(ApplicationDbContext db, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> SignInAsync(UserAuthDto userAuthDto)
        {
            var User = await _userManager.FindByIdAsync(userAuthDto.Email);
            var Result = await  _signInManager.PasswordSignInAsync(User, userAuthDto.Password, userAuthDto.RememberMe, false);
            return Result.Succeeded;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var item = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(item);
            return result.Succeeded;
        }

        public async Task<bool> RegisterAsync(User user,string password)
        {
            var Result = await _userManager.CreateAsync(user, password);
            return Result.Succeeded;
        }



        public async Task<bool> UpdateAsync(string id, User user)
        {
            user.Id = id;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
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
