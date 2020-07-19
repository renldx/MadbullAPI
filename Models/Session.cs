using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MadbullAPI.Models
{
    public class Session
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Exercise { get; set; }

        public int Order { get; set; }

        public int Sets { get; set; }
    }
}
