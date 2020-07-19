using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MadbullAPI.Models
{
    public class Session
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public Exercise Exercise { get; set; }

        public int Order { get; set; }

        public IEnumerable<Set> Sets { get; set; }
    }
}
