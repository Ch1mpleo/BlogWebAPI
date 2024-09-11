using BlogWeb.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWeb.Repository.Repositories
{
    public class UserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityUser>
         GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IdentityUser>
         GetUserByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);

        }

        public async Task<IdentityUser> CreateAsync(IdentityUser user)
        {
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
            return user;
        }

        public async Task<IdentityUser> UpdateAsync(IdentityUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to update user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
            return user;
        }

        public async Task<IdentityResult> DeleteAsync(IdentityUser user)
        {
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to delete user !!!");
            }
            return result;
        }

    }
}
