using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ShoCoWo.Data;

[assembly: OwinStartup(typeof(ShoCoWo.Api.Startup))]

namespace ShoCoWo.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));

                if (!roleManager.RoleExists("admin"))
                {
                    var role = new IdentityRole();
                    role.Name = "admin";
                    roleManager.Create(role);

                    var user = new ApplicationUser();
                    user.UserName = "admin";
                    user.Email = "admin@admin.com";

                    string userPassword = "Test1!";

                    var chkUser = userManager.Create(user, userPassword);

                    if (chkUser.Succeeded)
                        userManager.AddToRole(user.Id, "admin");
                }
            }
        }
    }
}
