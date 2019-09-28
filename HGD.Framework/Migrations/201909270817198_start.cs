namespace HGD.Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppInfo",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Secret = c.String(maxLength: 100, unicode: false),
                        Name = c.String(maxLength: 100, storeType: "nvarchar"),
                        CreatTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppSession",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Value = c.String(maxLength: 2000, storeType: "nvarchar"),
                        CreatTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExperimentHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Correct = c.Int(nullable: false),
                        Error = c.Int(nullable: false),
                        Score = c.Double(nullable: false),
                        CreatTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExperimentHistoryDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExperimentId = c.Int(nullable: false),
                        Title = c.String(unicode: false),
                        CorrectAnswer = c.String(unicode: false),
                        Result = c.Int(nullable: false),
                        Answer = c.String(unicode: false),
                        CreatTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ForumReplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ForumThemeId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        UserName = c.String(unicode: false),
                        UserId = c.String(unicode: false),
                        Content = c.String(unicode: false),
                        CreatTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ForumThemes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(unicode: false),
                        UserId = c.String(unicode: false),
                        Theme = c.String(unicode: false),
                        Content = c.String(unicode: false),
                        Replics = c.String(unicode: false),
                        Pictures = c.String(unicode: false),
                        CreatTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sys_User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50, unicode: false),
                        CreatTime = c.DateTime(precision: 0),
                        Name = c.String(unicode: false),
                        Account = c.String(unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(unicode: false),
                        Account = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        CreatTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Sys_User");
            DropTable("dbo.ForumThemes");
            DropTable("dbo.ForumReplies");
            DropTable("dbo.ExperimentHistoryDetails");
            DropTable("dbo.ExperimentHistories");
            DropTable("dbo.AppSession");
            DropTable("dbo.AppInfo");
        }
    }
}
