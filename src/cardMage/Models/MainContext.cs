using System.Data.Entity;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Collections.Generic;

namespace cardMage.Models
{
    public class DatabaseVersion
    {
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
    }

    public class MainContext
    {
        public MongoCollection<UserProfile> UserProfiles { get; set; }
        public MongoCollection<Carta> Cartas { get; set; }
        public MongoCollection<Baralho> Baralhos { get; set; }

        private MongoDatabase database;

        public MainContext()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            database = server.GetDatabase("cardMage");

            Cartas = database.GetCollection<Carta>("cartas");
            Baralhos = database.GetCollection<Baralho>("baralhos");
            UserProfiles = database.GetCollection<UserProfile>("usuarios");

            if (Cartas.Count() <= 0)
            {
                Baralhos.RemoveAll();
                Cartas.RemoveAll();
                UserProfiles.RemoveAll();
                Seed();

            }
        }

        public void Seed()
        {
            SeedUsuarios();
            SeedCartas();
            SeedBaralhos();
        }

        private void SeedUsuarios()
        {
            this.UserProfiles.Insert(new UserProfile() { UserId = 1, UserName = "aprendiz01" });
        }

        private void SeedCartas()
        {
            Mana zero = new Mana();
            Mana p2 = new Mana() { Preta = 2 };
            Mana p1 = new Mana() { Preta = 1 };
            Mana b2 = new Mana() { Branca = 2 };
            Mana b1 = new Mana() { Branca = 1 };

            this.Cartas.Insert(
              new Carta { Codigo = "T01", Nome = "Pântano", TipoCarta = TipoCarta.Terreno, Imagem = "pantano.jpg", Custo = zero });
            this.Cartas.Insert(
              new Carta { Codigo = "T02", Nome = "Planície", TipoCarta = TipoCarta.Terreno, Imagem = "planicie.jpg", Custo = zero });
            this.Cartas.Insert(
              new Carta { Codigo = "H01", Nome = "Shadow Master", TipoCarta = TipoCarta.Heroi, Imagem = "blackhero.jpg", Ataque = 0, Defesa = 20, Custo = zero });
            this.Cartas.Insert(
              new Carta { Codigo = "H02", Nome = "Light Lord", TipoCarta = TipoCarta.Heroi, Imagem = "whitehero.jpg", Ataque = 0, Defesa = 20, Custo = zero });
            this.Cartas.Insert(
              new Carta { Codigo = "C01", Nome = "Black Knight", TipoCarta = TipoCarta.Criatura, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 2, Custo = p2 });
            this.Cartas.Insert(
              new Carta { Codigo = "C02", Nome = "Dark Rider", TipoCarta = TipoCarta.Criatura, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 1, Custo = p1 });
            this.Cartas.Insert(
              new Carta { Codigo = "C03", Nome = "White Knight", TipoCarta = TipoCarta.Criatura, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 2, Custo = b2 });
            this.Cartas.Insert(
              new Carta { Codigo = "C04", Nome = "White Soldier", TipoCarta = TipoCarta.Criatura, Imagem = "whitehero.jpg", Ataque = 2, Defesa = 1, Custo = b1 });

        }

        private void SeedBaralhos()
        {
            Baralho b = new Baralho();
            b.Nome = "Computador01";
            b.HeroiId = "H01";
            b.Cartas = new string[] { 
                "T01", "T01", "T01", "T01", "T01", "T01", "T01", "T01", "T01", "T01", 
                "T01", "T01", "T01", "T01", "T01", "T01", "T01", "T01", "T01", "T01", 
                "C01", "C01", "C01", "C01", 
                "C01", "C01", "C01", "C01", 
                "C01", "C01", "C01", "C01", 
                "C01", "C01", "C01", "C01", 
                "C01", "C01", "C01", "C01", 
                "C02", "C02", "C02", "C02",
                "C02", "C02", "C02", "C02",
                "C02", "C02", "C02", "C02",
                "C02", "C02", "C02", "C02",
                "C02", "C02", "C02", "C02" 
            };
            this.Baralhos.Insert(b);

            b = new Baralho();
            b.Nome = "Usuario01";
            b.HeroiId = "H02";
            b.Cartas = new string[] { 
                "T02", "T02", "T02", "T02", "T02", "T02", "T02", "T02", "T02", "T02", 
                "T02", "T02", "T02", "T02", "T02", "T02", "T02", "T02", "T02", "T02", 
                "C03", "C03", "C03", "C03", 
                "C03", "C03", "C03", "C03", 
                "C03", "C03", "C03", "C03", 
                "C03", "C03", "C03", "C03", 
                "C03", "C03", "C03", "C03", 
                "C04", "C04", "C04", "C04", 
                "C04", "C04", "C04", "C04", 
                "C04", "C04", "C04", "C04", 
                "C04", "C04", "C04", "C04", 
                "C04", "C04", "C04", "C04"
            };
            this.Baralhos.Insert(b);
        }
    }
}