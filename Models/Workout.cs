using System.Collections.Generic;
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MadbullAPI.Enums;

namespace MadbullAPI.Models
{
    public class Workout
    {
        public Workout(Cycle cycle, IEnumerable<Session>? sessions = null)
        {
            Cycle = cycle;
            Sessions = sessions ?? new List<Session>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public DateTime Date { get; set; }

        public Cycle Cycle { get; set; }

        public WorkoutType WorkoutType { get; set; }

        public IEnumerable<Session> Sessions { get; set; }
    }
}
