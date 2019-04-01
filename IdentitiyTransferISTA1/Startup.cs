using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using IdentitiyTransferISTA1.Models;

[assembly: OwinStartupAttribute(typeof(IdentitiyTransferISTA1.Startup))]
namespace IdentitiyTransferISTA1
{
    public partial class Startup
    {

        ApplicationDbContext Db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreatRoles();
            CreatUser();
            CreatUserSecond();
        }
        public void CreatUser()
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Db));

            var user = new ApplicationUser();
            user.Email = "abayoss@yahoo.com";
            user.UserName = "abayoss";
            var check = UserManager.Create(user, "abayoss123");
            if (check.Succeeded)
            {
                UserManager.AddToRole(user.Id, "Admins");
            }
        }
        public void CreatUserSecond()
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Db));

            var user = new ApplicationUser();
            user.Email = "UserSecond@yahoo.com";
            user.UserName = "UserSecond";
            var check = UserManager.Create(user, "UserSecond123");
            if (check.Succeeded)
            {
                UserManager.AddToRole(user.Id, "Professors");
            }
        }
        public void CreatRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(Db));
            IdentityRole role;
            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Students"))
            {
                role = new IdentityRole();
                role.Name = "Students";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Professors"))
            {
                role = new IdentityRole();
                role.Name = "Professors";
                roleManager.Create(role);
            }
        }
    }
}
