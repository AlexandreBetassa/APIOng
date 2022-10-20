using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ApiOng.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<Animal> Animals { get; set; }
    }
}
