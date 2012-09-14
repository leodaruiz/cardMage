using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cardMage.Models
{
    public class Baralho
    {
        [BsonId]
        public ObjectId ObjectId;

        [ScaffoldColumn(false)]
        public string Id
        {
            get { return ObjectId.ToString(); }
            set { ObjectId = new ObjectId(value); }
        }

        [Key]
        public string Nome { get; set; }
        public string HeroiId { get; set; }
        public string[] Cartas { get; set; }
    }
}