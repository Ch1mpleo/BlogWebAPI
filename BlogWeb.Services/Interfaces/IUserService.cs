using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWeb.Services.Interfaces
{
    public interface IUserService
    {
        Task<IdentityUser> GetUserByIdAsync(string id);
        Task<IdentityUser> GetUserByUsernameAsync(string username);
        Task<IdentityUser> GetUserByEmailAsync(string email);
        Task<IdentityUser> CreateUserAsync(IdentityUser user, string password);
        Task<IdentityUser> UpdateUserAsync(IdentityUser user);
        Task<IdentityResult> DeleteUserAsync(IdentityUser user);
    }
}
