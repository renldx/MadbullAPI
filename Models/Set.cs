using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MadbullAPI.Models
{
    public class Set
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public int Order { get; set; }

        public int Intensity { get; set; }

        public int PrescribedReps { get; set; }

        public int PerformedReps { get; set; }
    }
}
