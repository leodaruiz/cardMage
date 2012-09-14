using System.Data.Entity;
using MongoDB.Driver;

namespace cardMage.Models
{
    public class MainContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public MongoCollection<Carta> Cartas { get; set; }
        public MongoCollection<TipoCarta> TiposCarta { get; set; }
        public MongoCollection<Baralho> Baralhos { get; set; }

        public TipoCarta terreno = new TipoCarta() { Tipo = "Terreno" };
        public TipoCarta heroi = new TipoCarta() { Tipo = "Herói" };
        public TipoCarta criatura = new TipoCarta() { Tipo = "Criatura" };
        public TipoCarta magica = new TipoCarta() { Tipo = "Mágica" };
        public TipoCarta encantamento = new TipoCarta() { Tipo = "Encantamento" };

        public MainContext()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("cardMage");

            Cartas = database.GetCollection<Carta>("cartas");
            TiposCarta = database.GetCollection<TipoCarta>("tiposcarta");
            Baralhos = database.GetCollection<Baralho>("baralhos");
        }

        public void Seed()
        {
            this.UserProfiles.AddOrUpdate(new UserProfile() { UserId = 1, UserName = "aprendiz01" });


            this.TiposCarta.Insert(terreno);
            this.TiposCarta.Insert(heroi);
            this.TiposCarta.Insert(criatura);
            this.TiposCarta.Insert(magica);
            this.TiposCarta.Insert(encantamento);
            
            Mana zero = new Mana();
            Mana p2 = new Mana() { Preta = 2 };
            Mana p1 = new Mana() { Preta = 1 };
            Mana b2 = new Mana() { Branca = 2 };
            Mana b1 = new Mana() { Branca = 1 };

            this.Cartas.AddOrUpdate(
              new Carta { Id = "T01", Nome = "Pântano", TipoCartaID = context.terreno.Id, Imagem = "pantano.jpg", Custo = zero },
              new Carta { Id = "T02", Nome = "Planície", TipoCartaID = context.terreno.Id, Imagem = "planicie.jpg", Custo = zero },
              new Carta { Id = "H01", Nome = "Shadow Master", TipoCartaID = context.heroi.Id, Imagem = "blackhero.jpg", Ataque = 0, Defesa = 20, Custo = zero },
              new Carta { Id = "H02", Nome = "Light Lord", TipoCartaID = context.heroi.Id, Imagem = "whitehero.jpg", Ataque = 0, Defesa = 20, Custo = zero },
              new Carta { Id = "C01", Nome = "Black Knight", TipoCartaID = context.criatura.Id, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 2, Custo = p2 },
              new Carta { Id = "C02", Nome = "Dark Rider", TipoCartaID = context.criatura.Id, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 1, Custo = p1 },
              new Carta { Id = "C03", Nome = "White Knight", TipoCartaID = context.criatura.Id, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 2, Custo = b2 },
              new Carta { Id = "C04", Nome = "White Soldier", TipoCartaID = context.criatura.Id, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 1, Custo = b1 }
            );
        }
    }
}