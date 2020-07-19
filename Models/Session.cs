using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MadbullAPI.Models
{
    public class Session
    {
        public Session(Exercise exercise, int order, IEnumerable<Set>? sets = null)
        {
            Exercise = exercise;
            Order = order;
            Sets = sets ?? new List<Set>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public Exercise Exercise { get; set; }

        public int Order { get; set; }

        public IEnumerable<Set> Sets { get; set; }
    }
}
