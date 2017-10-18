using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BaBookStudentai.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaBookStudentai.Entities
{
    public class User : IdentityUser<int, CustomUserLogin, CustomUserRole, 
        CustomUserClaim>
    { 
        //[Key]
        //public int UserId { get; set; }
        //public string Username { get; set; }
        //public virtual List<Event> UserEvents { get; set; }
        public virtual List<Group> UserGroups { get; set; }
        public virtual List<EventUser> EventUsers { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserStore : UserStore<User, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(BaBookDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(BaBookDbContext context)
            : base(context)
        {
        }
    }
}