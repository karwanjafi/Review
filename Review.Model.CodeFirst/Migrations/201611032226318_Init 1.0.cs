namespace Review.Model.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AddressLine1 = c.String(nullable: false, maxLength: 200),
                        AddressLine2 = c.String(maxLength: 200),
                        PostCode = c.String(maxLength: 20),
                        TelNo = c.String(maxLength: 20),
                        FaxNo = c.String(maxLength: 20),
                        Location = c.Geography(),
                        Business_Id = c.Guid(),
                        City_Id = c.Int(nullable: false),
                        Tag_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.Business_Id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Business_Id)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Logo = c.String(),
                        Bio = c.String(),
                        AverageScore = c.Short(nullable: false),
                        LastCalculationDateTime = c.DateTime(),
                        Tag_Id = c.Guid(nullable: false),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Tags", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        User_Id = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 100),
                        Family = c.String(maxLength: 100),
                        RegisterationDateTime = c.DateTime(nullable: false),
                        IsActivate = c.Boolean(nullable: false),
                        ActivationDateTime = c.DateTime(),
                        Status = c.Short(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        User_Id = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Reviewers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RegisterationSource = c.Byte(nullable: false),
                        LastCommentDateTime = c.DateTime(),
                        Gender = c.Short(nullable: false),
                        Bio = c.String(nullable: false),
                        BirthDay = c.String(nullable: false),
                        Interest = c.String(nullable: false),
                        EducationDegree = c.Short(nullable: false),
                        Country_Id = c.Int(),
                        User_Id = c.String(nullable: false),
                        Country_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id1)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.Country_Id1);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 100),
                        Status = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Status = c.Short(nullable: false),
                        Code = c.String(maxLength: 10),
                        Country_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 500),
                        SubmitDateTime = c.DateTime(nullable: false),
                        SubmitIP = c.String(nullable: false, maxLength: 15),
                        SubmitLatitude = c.Decimal(precision: 18, scale: 2),
                        SubmitLongitude = c.Decimal(precision: 18, scale: 2),
                        IsConfirm = c.Boolean(nullable: false),
                        Type = c.Short(nullable: false),
                        IsAnonymous = c.Boolean(nullable: false),
                        ToBlackList = c.Boolean(nullable: false),
                        Reviewer_Id = c.Guid(nullable: false),
                        Location_Id = c.Int(),
                        Business_Id = c.Guid(nullable: false),
                        Tag_Id = c.Guid(nullable: false),
                        ScoreBand_Id = c.Short(nullable: false),
                        Reviewer_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reviewers", t => t.Reviewer_Id1)
                .ForeignKey("dbo.ScoreBands", t => t.ScoreBand_Id)
                .ForeignKey("dbo.Tags", t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.Business_Id)
                .Index(t => t.Id)
                .Index(t => t.Business_Id)
                .Index(t => t.ScoreBand_Id)
                .Index(t => t.Reviewer_Id1);
            
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
                        Review_Id = c.Guid(),
                        Address_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Tag_Id = c.Guid(nullable: false),
                        Tag_Id1 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Parent_Id)
                .ForeignKey("dbo.Tags", t => t.Tag_Id1)
                .Index(t => t.Parent_Id)
                .Index(t => t.Tag_Id1);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        RoleId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BusinessOwner",
                c => new
                    {
                        Business_Id = c.Guid(nullable: false),
                        Owner_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Business_Id, t.Owner_Id })
                .ForeignKey("dbo.Businesses", t => t.Business_Id, cascadeDelete: true)
                .ForeignKey("dbo.Owners", t => t.Owner_Id, cascadeDelete: true)
                .Index(t => t.Business_Id)
                .Index(t => t.Owner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Addresses", "Id", "dbo.Tags");
            DropForeignKey("dbo.Businesses", "Id", "dbo.Tags");
            DropForeignKey("dbo.Reviews", "Business_Id", "dbo.Businesses");
            DropForeignKey("dbo.BusinessOwner", "Owner_Id", "dbo.Owners");
            DropForeignKey("dbo.BusinessOwner", "Business_Id", "dbo.Businesses");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reviewers", "Id", "dbo.Users");
            DropForeignKey("dbo.Reviews", "Id", "dbo.Tags");
            DropForeignKey("dbo.Categories", "Tag_Id1", "dbo.Tags");
            DropForeignKey("dbo.Categories", "Parent_Id", "dbo.Categories");
            DropForeignKey("dbo.Reviews", "ScoreBand_Id", "dbo.ScoreBands");
            DropForeignKey("dbo.Reviews", "Reviewer_Id1", "dbo.Reviewers");
            DropForeignKey("dbo.Reviewers", "Country_Id1", "dbo.Countries");
            DropForeignKey("dbo.Users", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Addresses", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Businesses", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Owners", "Id", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Admins", "Id", "dbo.Users");
            DropForeignKey("dbo.Addresses", "Business_Id", "dbo.Businesses");
            DropIndex("dbo.BusinessOwner", new[] { "Owner_Id" });
            DropIndex("dbo.BusinessOwner", new[] { "Business_Id" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Categories", new[] { "Tag_Id1" });
            DropIndex("dbo.Categories", new[] { "Parent_Id" });
            DropIndex("dbo.Reviews", new[] { "Reviewer_Id1" });
            DropIndex("dbo.Reviews", new[] { "ScoreBand_Id" });
            DropIndex("dbo.Reviews", new[] { "Business_Id" });
            DropIndex("dbo.Reviews", new[] { "Id" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropIndex("dbo.Reviewers", new[] { "Country_Id1" });
            DropIndex("dbo.Reviewers", new[] { "Id" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Admins", new[] { "Id" });
            DropIndex("dbo.Users", new[] { "Country_Id" });
            DropIndex("dbo.Owners", new[] { "Id" });
            DropIndex("dbo.Businesses", new[] { "Country_Id" });
            DropIndex("dbo.Businesses", new[] { "Id" });
            DropIndex("dbo.Addresses", new[] { "City_Id" });
            DropIndex("dbo.Addresses", new[] { "Business_Id" });
            DropIndex("dbo.Addresses", new[] { "Id" });
            DropTable("dbo.BusinessOwner");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Categories");
            DropTable("dbo.Tags");
            DropTable("dbo.ScoreBands");
            DropTable("dbo.Reviews");
            DropTable("dbo.Cities");
            DropTable("dbo.Countries");
            DropTable("dbo.Reviewers");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Admins");
            DropTable("dbo.Users");
            DropTable("dbo.Owners");
            DropTable("dbo.Businesses");
            DropTable("dbo.Addresses");
        }
    }
}
