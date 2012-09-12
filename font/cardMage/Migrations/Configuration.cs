namespace cardMage.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using cardMage.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<cardMage.Models.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(cardMage.Models.MainContext context)
        {
            context.UserProfiles.AddOrUpdate(new UserProfile() { UserId = 1, UserName = "aprendiz01" });
            
            

            context.TiposCarta.AddOrUpdate(
                context.terreno, context.heroi, context.criatura, context.magica, context.encantamento
                );

            Mana z = new Mana();
            Mana p2 = new Mana() { Preta = 2 };
            Mana p1 = new Mana() { Preta = 1 };
            Mana b2 = new Mana() { Branca = 2 };
            Mana b1 = new Mana() { Branca = 1 };

            context.Cartas.AddOrUpdate(
              new Carta { Id = "T01", Nome = "Pântano", TipoCartaID = context.terreno.Id, Imagem = "pantano.jpg", Custo = z },
              new Carta { Id = "T02", Nome = "Planície", TipoCartaID = context.terreno.Id, Imagem = "planicie.jpg", Custo = z },
              new Carta { Id = "H01", Nome = "Shadow Master", TipoCartaID = context.heroi.Id, Imagem = "blackhero.jpg", Ataque = 0, Defesa = 20, Custo = z },
              new Carta { Id = "H02", Nome = "Light Lord", TipoCartaID = context.heroi.Id, Imagem = "whitehero.jpg", Ataque = 0, Defesa = 20, Custo = z },
              new Carta { Id = "C01", Nome = "Black Knight", TipoCartaID = context.criatura.Id, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 2, Custo = p2 },
              new Carta { Id = "C02", Nome = "Dark Rider", TipoCartaID = context.criatura.Id, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 1, Custo = p1 },
              new Carta { Id = "C03", Nome = "White Knight", TipoCartaID = context.criatura.Id, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 2, Custo = b2 },
              new Carta { Id = "C04", Nome = "White Soldier", TipoCartaID = context.criatura.Id, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 1, Custo = b1 }
            );
        }
    }
}
