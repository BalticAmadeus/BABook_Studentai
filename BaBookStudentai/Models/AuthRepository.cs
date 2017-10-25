using System;
using System.Threading.Tasks;
using BaBookStudentai.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaBookStudentai.Models
{
    public class AuthRepository : IDisposable
    {
        private BaBookDbContext _ctx;

        private UserManager<User> _userManager;

        public AuthRepository()
        {
            _ctx = new BaBookDbContext();
            _userManager = new UserManager<User>(new UserStore<User>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserViewModel userModel)
        {
            User user = new User
            {
                UserName = userModel.Email,
                Nickname = userModel.Username
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<User> FindUser(string userName, string password)
        {
            User user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }

    }
}