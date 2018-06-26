using CarCom.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarCom.Startup))]
namespace CarCom
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();

        }
        public void CreateDefaultRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var UserManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();

            if(!roleManager.RoleExists("Admins"))
            {
                role.Name = "Admins";
                roleManager.Create(role);
                ApplicationUser User = new Models.ApplicationUser();
                User.UserName= "mosageneral@gmail.com";
                User.Email= "mosageneral@gmail.com";
                var check = UserManger.Create(User, "2452535Mosa@");
                if(check .Succeeded )
                {
                    UserManger.AddToRole(User.Id, "Admins");
              }
             }
        }
    }
}
