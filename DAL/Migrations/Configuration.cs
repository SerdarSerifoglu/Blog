namespace DAL.Migrations
{
    using Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.BlogContext context)
        {
            //context.Roles.AddOrUpdate(x => x.Name, new IdentityRole() { Name = "Admin" });
            //if (context.Users.Count() == 0)
            //{

            //    UserStore<IdentityUser> us = new UserStore<IdentityUser>(new BlogContext());
            //    UserManager<IdentityUser> um = new UserManager<IdentityUser>(us);
            //    IdentityUser user1 = new IdentityUser();
            //    user1.Email = "serdarserifoglu@gmail.com";
            //    user1.UserName = "serdarserifoglu@gmail.com";
            //    um.Create(user1, "Aa123456_");
            //    var rolesForUser = um.GetRoles(user1.Id);
            //    if (!rolesForUser.Contains("Admin"))
            //    {
            //        um.AddToRole(user1.Id, "Admin");
            //    }
            //    context.SaveChanges();
            //}


            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }
           
            if (!context.Users.Any(u => u.UserName == "serdarserifoglu@gmail.com"))
            {
                var store = new UserStore<IdentityUser>(context);
                var manager = new UserManager<IdentityUser>(store);
                var user = new IdentityUser { UserName = "serdarserifoglu@gmail.com" };

                manager.Create(user, "Aa123456_");
                manager.AddToRole(user.Id, "Admin");
            }
           
        }

    }
}
