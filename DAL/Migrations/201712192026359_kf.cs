namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriBaslik = c.String(),
                        KategoriIcerik = c.String(),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.Yazis",
                c => new
                    {
                        YaziId = c.Int(nullable: false, identity: true),
                        YaziKategoriId = c.Int(nullable: false),
                        YaziBasligi = c.String(nullable: false, maxLength: 150),
                        YaziIcerigi = c.String(nullable: false, unicode: false, storeType: "text"),
                        Etiket = c.String(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        BegenilmeSayisi = c.Int(nullable: false),
                        SeoTitle = c.String(nullable: false, maxLength: 57),
                        SeoDesc = c.String(nullable: false, maxLength: 160),
                        SeoKeywords = c.String(),
                    })
                .PrimaryKey(t => t.YaziId)
                .ForeignKey("dbo.Kategoris", t => t.YaziKategoriId, cascadeDelete: true)
                .Index(t => t.YaziKategoriId);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        LikeId = c.Int(nullable: false, identity: true),
                        UyeIdLike = c.String(),
                        LikeTarihi = c.DateTime(nullable: false),
                        LikelananYazi_YaziId = c.Int(),
                    })
                .PrimaryKey(t => t.LikeId)
                .ForeignKey("dbo.Yazis", t => t.LikelananYazi_YaziId)
                .Index(t => t.LikelananYazi_YaziId);
            
            CreateTable(
                "dbo.Yorums",
                c => new
                    {
                        YorumId = c.Int(nullable: false, identity: true),
                        YorumBaslik = c.String(nullable: false, maxLength: 100),
                        YorumIcerik = c.String(nullable: false, maxLength: 500),
                        YorumlayanUyeId = c.String(),
                        YorumTarihi = c.DateTime(nullable: false),
                        YorumlananYazi_YaziId = c.Int(),
                    })
                .PrimaryKey(t => t.YorumId)
                .ForeignKey("dbo.Yazis", t => t.YorumlananYazi_YaziId)
                .Index(t => t.YorumlananYazi_YaziId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Yorums", "YorumlananYazi_YaziId", "dbo.Yazis");
            DropForeignKey("dbo.Likes", "LikelananYazi_YaziId", "dbo.Yazis");
            DropForeignKey("dbo.Yazis", "YaziKategoriId", "dbo.Kategoris");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Yorums", new[] { "YorumlananYazi_YaziId" });
            DropIndex("dbo.Likes", new[] { "LikelananYazi_YaziId" });
            DropIndex("dbo.Yazis", new[] { "YaziKategoriId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Yorums");
            DropTable("dbo.Likes");
            DropTable("dbo.Yazis");
            DropTable("dbo.Kategoris");
        }
    }
}
