namespace HGD.Framework.Migrations
{
    using HGD.Framework.Orm.SPMS.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<HGD.Framework.Orm.HGDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HGD.Framework.Orm.HGDContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Sys_User.Add(new Sys_User
            {
                Id = "1",
                Account = "admin",
                Name = "超级管理员",
                Password = "e10adc3949ba59abbe56e057f20f883e"
            });
            context.SaveChanges();
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
