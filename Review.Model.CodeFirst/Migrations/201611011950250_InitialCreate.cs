namespace Review.Model.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AddressLine1 = c.String(nullable: false, maxLength: 200),
                        AddressLine2 = c.String(nullable: false, maxLength: 200),
                        PostCode = c.String(nullable: false, maxLength: 20),
                        TelNo = c.String(nullable: false, maxLength: 20),
                        FaxNo = c.String(nullable: false, maxLength: 20),
                        Location = c.Geography(nullable: false),
                        City_Id = c.Int(nullable: false),
                        Business_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.Business_Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Business_Id);
            
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Logo = c.String(nullable: false),
                        Bio = c.String(nullable: false),
                        AverageScore = c.Short(nullable: false),
                        LastCalculationDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Comment = c.String(nullable: false),
                        SubmitDateTime = c.String(nullable: false),
                        SubmitIP = c.String(nullable: false),
                        SubmitLatitude = c.String(nullable: false),
                        SubmitLongitude = c.String(nullable: false),
                        IsConfirm = c.String(nullable: false),
                        Type = c.Short(nullable: false),
                        IsAnonymous = c.Boolean(nullable: false),
                        ToBlackList = c.Boolean(nullable: false),
                        ScoreBand_Id = c.Short(nullable: false),
                        Reviewer_Id = c.Guid(nullable: false),
                        City_Id = c.Int(),
                        Location_Id = c.Int(),
                        Business_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Location_Id)
                .ForeignKey("dbo.Users_Reviewer", t => t.Reviewer_Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.ScoreBands", t => t.ScoreBand_Id)
                .ForeignKey("dbo.Businesses", t => t.Business_Id)
                .Index(t => t.ScoreBand_Id)
                .Index(t => t.Reviewer_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Business_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Status = c.Short(nullable: false),
                        Code = c.String(nullable: false, maxLength: 10),
                        Country_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Status = c.Short(nullable: false),
                        Code = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users_Reviewer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RegisterationSource = c.Byte(nullable: false),
                        LastCommentDateTime = c.DateTime(),
                        Gender = c.Short(nullable: false),
                        Bio = c.String(nullable: false),
                        BirthDay = c.String(nullable: false),
                        Interest = c.String(nullable: false),
                        EducationDegree = c.Short(nullable: false),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100),
                        Family = c.String(maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(maxLength: 20),
                        RegisterationDateTime = c.DateTime(nullable: false),
                        IsActivate = c.Boolean(nullable: false),
                        ActivationType = c.Byte(nullable: false),
                        ActivationDateTime = c.DateTime(),
                        Status = c.Short(nullable: false),
                        Salt = c.String(nullable: false),
                        Login_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.Login_Id)
                .Index(t => t.Login_Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoginDateTime = c.DateTime(nullable: false),
                        Token = c.String(nullable: false),
                        TokenIp = c.String(nullable: false),
                        LoginDevice = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users_Admin",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users_Owner",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ScoreBands",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Star = c.String(nullable: false),
                        Score = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TagName = c.String(nullable: false),
                        Searchable = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                        Business_Id = c.Guid(),
                        Review_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Reviews", t => t.Review_Id)
                .ForeignKey("dbo.Businesses", t => t.Business_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Business_Id)
                .Index(t => t.Review_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Status = c.Short(nullable: false),
                        Bio = c.String(nullable: false),
                        Logo = c.String(nullable: false),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.BusinessOwner",
                c => new
                    {
                        Business_Id = c.Guid(nullable: false),
                        Owners_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Business_Id, t.Owners_Id })
                .ForeignKey("dbo.Businesses", t => t.Business_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users_Owner", t => t.Owners_Id, cascadeDelete: true)
                .Index(t => t.Business_Id)
                .Index(t => t.Owners_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusinessOwner", "Owners_Id", "dbo.Users_Owner");
            DropForeignKey("dbo.BusinessOwner", "Business_Id", "dbo.Businesses");
            DropForeignKey("dbo.Tags", "Business_Id", "dbo.Businesses");
            DropForeignKey("dbo.Reviews", "Business_Id", "dbo.Businesses");
            DropForeignKey("dbo.Tags", "Review_Id", "dbo.Reviews");
            DropForeignKey("dbo.Tags", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Parent_Id", "dbo.Categories");
            DropForeignKey("dbo.Reviews", "ScoreBand_Id", "dbo.ScoreBands");
            DropForeignKey("dbo.Reviews", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Users_Reviewer", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Users_Reviewer", "Id", "dbo.Users");
            DropForeignKey("dbo.Users_Owner", "Id", "dbo.Users");
            DropForeignKey("dbo.Users_Admin", "Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Login_Id", "dbo.Logins");
            DropForeignKey("dbo.Reviews", "Reviewer_Id", "dbo.Users_Reviewer");
            DropForeignKey("dbo.Reviews", "Location_Id", "dbo.Countries");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Addresses", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Addresses", "Business_Id", "dbo.Businesses");
            DropIndex("dbo.BusinessOwner", new[] { "Owners_Id" });
            DropIndex("dbo.BusinessOwner", new[] { "Business_Id" });
            DropIndex("dbo.Categories", new[] { "Parent_Id" });
            DropIndex("dbo.Tags", new[] { "Review_Id" });
            DropIndex("dbo.Tags", new[] { "Business_Id" });
            DropIndex("dbo.Tags", new[] { "Category_Id" });
            DropIndex("dbo.Users_Owner", new[] { "Id" });
            DropIndex("dbo.Users_Admin", new[] { "Id" });
            DropIndex("dbo.Users", new[] { "Login_Id" });
            DropIndex("dbo.Users_Reviewer", new[] { "Country_Id" });
            DropIndex("dbo.Users_Reviewer", new[] { "Id" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropIndex("dbo.Reviews", new[] { "Business_Id" });
            DropIndex("dbo.Reviews", new[] { "Location_Id" });
            DropIndex("dbo.Reviews", new[] { "City_Id" });
            DropIndex("dbo.Reviews", new[] { "Reviewer_Id" });
            DropIndex("dbo.Reviews", new[] { "ScoreBand_Id" });
            DropIndex("dbo.Addresses", new[] { "Business_Id" });
            DropIndex("dbo.Addresses", new[] { "City_Id" });
            DropTable("dbo.BusinessOwner");
            DropTable("dbo.Categories");
            DropTable("dbo.Tags");
            DropTable("dbo.ScoreBands");
            DropTable("dbo.Users_Owner");
            DropTable("dbo.Users_Admin");
            DropTable("dbo.Logins");
            DropTable("dbo.Users");
            DropTable("dbo.Users_Reviewer");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Reviews");
            DropTable("dbo.Businesses");
            DropTable("dbo.Addresses");
        }
    }
}
