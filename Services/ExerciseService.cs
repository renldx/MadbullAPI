using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MadbullAPI.Models;

namespace MadbullAPI.Services
{
    public class ExerciseService
    {
        private readonly IMongoCollection<Exercise> exercises;

        public ExerciseService(IMadbullDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            exercises = database.GetCollection<Exercise>(settings.ExercisesCollectionName);
        }

        public List<Exercise> Get() => exercises.Find(exercise => true).ToList();

        public Exercise Get(string id) =>
            exercises.Find(exercise => exercise.Id == id).FirstOrDefault();

        public Exercise Create(Exercise exercise)
        {
            exercises.InsertOne(exercise);
            return exercise;
        }

        public void Update(string id, Exercise exerciseIn) =>
            exercises.ReplaceOne(exercise => exercise.Id == id, exerciseIn);

        public void Remove(Exercise exerciseIn) =>
            exercises.DeleteOne(exercise => exercise.Id == exerciseIn.Id);

        public void Remove(string id) =>
            exercises.DeleteOne(exercise => exercise.Id == id);
    }
}
