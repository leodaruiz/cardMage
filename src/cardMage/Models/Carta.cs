using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace cardMage.Models
{
    public class Carta
    {
        [BsonId]
        public ObjectId ObjectId;

        [ScaffoldColumn(false)]
        public string Id
        {
            get { return ObjectId.ToString(); }
            set { ObjectId = new ObjectId(value); }
        }

        public string Codigo { get; set; }

        public string Nome { get; set; }

        public TipoCarta TipoCarta { get; set; }

        public string Descricao { get; set; }

        private string imagem;

        public string Imagem
        {
            get { return imagem; }
            set { imagem = "../../Images/Cartas/" + value; }
        }

        public decimal Ataque { get; set; }

        public decimal Defesa { get; set; }

        public Mana Custo { get; set; }
    }
}