namespace cardMage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Cartas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 55),
                        Descricao = c.String(),
                        Ataque = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Defesa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoCarta_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoCartas", t => t.TipoCarta_Id, cascadeDelete: true)
                .Index(t => t.TipoCarta_Id);
            
            CreateTable(
                "dbo.TipoCartas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cartas", new[] { "TipoCarta_Id" });
            DropForeignKey("dbo.Cartas", "TipoCarta_Id", "dbo.TipoCartas");
            DropTable("dbo.TipoCartas");
            DropTable("dbo.Cartas");
            DropTable("dbo.UserProfile");
        }
    }
}
