using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MadbullAPI.Enums;

namespace MadbullAPI.Models
{
    public class Exercise
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public ResistanceType ResistanceType { get; set; }

        // 1RM in KGs
        public double ResistanceUnit { get; set; }

        // Ex. Leg Day, Lower Body, Push, etc.
        public IEnumerable<string> Tags { get; set; }
    }
}
