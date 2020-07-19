using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MadbullAPI.Models
{
    public class Cycle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
    }
}
