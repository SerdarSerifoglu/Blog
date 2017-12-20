namespace DAL.Migrations
{
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
            if (context.Users.Count() == 0)
            {
                UserStore<IdentityUser> str = new UserStore<IdentityUser>(new BlogContext());
                UserManager<IdentityUser> mng = new UserManager<IdentityUser>(str);
                var admin = new IdentityUser() { Email = "serdarserifoglu@gmail.com", UserName = "serdarserifoglu@gmail.com"};
                mng.Create(admin, "Aa123456_");
                context.SaveChanges();
                mng.AddToRole(admin.Id, "Admin");
                context.SaveChanges();
            }
        }
    }
}
