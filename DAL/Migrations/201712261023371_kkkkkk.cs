namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kkkkkk : DbMigration
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
            
            AddColumn("dbo.Yazis", "Kategori_KategoriId", c => c.Int());
            CreateIndex("dbo.Yazis", "Kategori_KategoriId");
            AddForeignKey("dbo.Yazis", "Kategori_KategoriId", "dbo.Kategoris", "KategoriId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yazis", "Kategori_KategoriId", "dbo.Kategoris");
            DropIndex("dbo.Yazis", new[] { "Kategori_KategoriId" });
            DropColumn("dbo.Yazis", "Kategori_KategoriId");
            DropTable("dbo.Kategoris");
        }
    }
}
