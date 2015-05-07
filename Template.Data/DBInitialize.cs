using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Template.Data
{
    public class DbInitialize<T> : DropCreateDatabaseIfModelChanges<IdentityDbContext>
        {
            protected override void Seed(IdentityDbContext context)
            {
                var userManager = new UserManager<ApplicationUser>(new 
                                                UserStore<ApplicationUser>(context)); 

                var roleManager = new RoleManager<ApplicationRole>(new 
                                          RoleStore<ApplicationRole>(context));
     
                const string name = "Admin";
                const string password = "password";
 
                if (!roleManager.RoleExists(name))
                {
                var roleresult = roleManager.Create(new ApplicationRole(name));
                }

                var user = new ApplicationUser();
                user.UserName = name;
                var adminresult = userManager.Create(user, password);

                if (adminresult.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, name);
                }
                base.Seed(context);
            }
        }
    }

