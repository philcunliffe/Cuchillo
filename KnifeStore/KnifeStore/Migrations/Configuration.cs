namespace KnifeStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<KnifeStore.DataAccess.KnifeStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(KnifeStore.DataAccess.KnifeStoreContext context)
        {
            WebSecurity.InitializeDatabaseConnection("KnifeStoreContext", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");

            if (!WebSecurity.UserExists("tprox"))
                WebSecurity.CreateUserAndAccount(
                    "tprox",
                    "nont!cRules",
                    new
                    {
                        FirstName = "Phillip",
                        LastName = "Cunliffe",
                        EmailAddress = "thirdplanetrox@gmail.com",
                        Birthday = DateTime.Now,
                        Subscribed = true
                    });

            if (!Roles.GetRolesForUser("tprox").Contains("Administrator"))
                Roles.AddUsersToRoles(new[] { "tprox" }, new[] { "Administrator" });

            if (!WebSecurity.UserExists("tprox"))
                WebSecurity.CreateUserAndAccount(
                    "neryam",
                    "nont!cRules",
                    new
                    {
                        FirstName = "Raymon",
                        LastName = "Ohmory",
                        EmailAddress = "neryam@gmail.com",
                        Birthday = DateTime.Now,
                        Subscribed = true
                    });

            if (!Roles.GetRolesForUser("neryam").Contains("Administrator"))
                Roles.AddUsersToRoles(new[] { "neryam" }, new[] { "Administrator" });
        }
    }
}
