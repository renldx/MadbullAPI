using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MadbullAPI.Models
{
    public class Workout
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public string Cycle { get; set; }

        // Light, Volume, Intensity, Other
        public int Type { get; set; }

        public int Sessions { get; set; }
    }
}
