using MongoDB.Bson;

namespace cardMage.Models
{
    public class Carta
    {
        public ObjectId Id { get; set; }

        public string Nome { get; set; }

        public int TipoCartaID { get; set; }

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