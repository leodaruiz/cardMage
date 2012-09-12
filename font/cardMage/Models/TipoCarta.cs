using MongoDB.Bson;

namespace cardMage.Models
{
    public class TipoCarta
    {
        public ObjectId Id { get; set; }

        public string Tipo { get; set; }
    }
}