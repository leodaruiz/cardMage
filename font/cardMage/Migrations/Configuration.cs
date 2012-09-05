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
            TipoCarta terreno = new TipoCarta() { Id = 1, Tipo = "Terreno" };
            TipoCarta heroi = new TipoCarta() { Id = 2, Tipo = "Herói" };
            TipoCarta criatura = new TipoCarta() { Id = 3, Tipo = "Criatura" };
            TipoCarta magica = new TipoCarta() { Id = 4, Tipo = "Mágica" };
            TipoCarta encantamento = new TipoCarta() { Id = 5, Tipo = "Encantamento" };

            context.TiposCarta.AddOrUpdate(
                terreno, heroi, criatura, magica, encantamento
                );

            Mana z = new Mana();
            Mana p2 = new Mana() { Preta = 2 };
            Mana p1 = new Mana() { Preta = 1 };
            Mana b2 = new Mana() { Branca = 2 };
            Mana b1 = new Mana() { Branca = 1 };

            context.Cartas.AddOrUpdate(
              new Carta { Id = "T01", Nome = "Pântano", TipoCartaID = terreno.Id, Imagem = "pantano.jpg", Custo=z },
              new Carta { Id = "T02", Nome = "Planície", TipoCartaID = terreno.Id, Imagem = "planicie.jpg", Custo = z },
              new Carta { Id = "H01", Nome = "Shadow Master", TipoCartaID = heroi.Id, Imagem = "blackhero.jpg", Ataque = 0, Defesa = 20, Custo = z },
              new Carta { Id = "H02", Nome = "Light Lord", TipoCartaID = heroi.Id, Imagem = "whitehero.jpg", Ataque = 0, Defesa = 20, Custo = z },
              new Carta { Id = "C01", Nome = "Black Knight", TipoCartaID = heroi.Id, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 2, Custo = p2 },
              new Carta { Id = "C02", Nome = "Dark Rider", TipoCartaID = heroi.Id, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 1, Custo = p1 },
              new Carta { Id = "C03", Nome = "White Knight", TipoCartaID = heroi.Id, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 2, Custo = b2 },
              new Carta { Id = "C04", Nome = "White Soldier", TipoCartaID = heroi.Id, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 1, Custo = b1 }
            );
        }
    }
}
