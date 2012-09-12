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
                        Id = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(nullable: false, maxLength: 55),
                        TipoCartaID = c.Int(nullable: false),
                        Descricao = c.String(),
                        Imagem = c.String(),
                        Ataque = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Defesa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Custo_Neutra = c.Int(nullable: false),
                        Custo_Branca = c.Int(nullable: false),
                        Custo_Preta = c.Int(nullable: false),
                        Mana_Neutra = c.Int(),
                        Mana_Branca = c.Int(),
                        Mana_Preta = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoCartas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Baralhoes",
                c => new
                    {
                        Nome = c.String(nullable: false, maxLength: 128),
                        HeroiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Nome);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Baralhoes");
            DropTable("dbo.TipoCartas");
            DropTable("dbo.Cartas");
            DropTable("dbo.UserProfile");
        }
    }
}
