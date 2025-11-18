using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend_math_api.Models
{
    public class Sector
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("topics")]
        public List<Topic> Topics { get; set; } = new();
    }
}