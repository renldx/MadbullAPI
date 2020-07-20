using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MadbullAPI.Models;

namespace MadbullAPI.Services
{
    public class WorkoutService : BaseService
    {
        private readonly IMongoCollection<Workout> workouts;

        public WorkoutService(IMadbullDatabaseSettings settings) : base(settings)
        {
            workouts = database.GetCollection<Workout>(settings.WorkoutsCollectionName);
        }

        public List<Workout> Get() => workouts.Find(workout => true).ToList();

        public Workout Get(string id) =>
            workouts.Find(workout => workout.Id == id).FirstOrDefault();

        public Workout Create(Workout workout)
        {
            workouts.InsertOne(workout);
            return workout;
        }

        public void Update(string id, Workout workoutIn) =>
            workouts.ReplaceOne(workout => workout.Id == id, workoutIn);

        public void Remove(Workout workoutIn) =>
            workouts.DeleteOne(workout => workout.Id == workoutIn.Id);

        public void Remove(string id) =>
            workouts.DeleteOne(workout => workout.Id == id);
    }
}
