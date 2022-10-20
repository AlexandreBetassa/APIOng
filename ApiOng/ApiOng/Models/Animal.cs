using MongoDB.Bson.Serialization.Attributes;

namespace ApiOng.Models
{
    public class Animal
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Family { get; set; }
    }
}
