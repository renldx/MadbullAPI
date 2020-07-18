using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MadbullAPI.Models;

namespace MadbullAPI.Services
{
    public class CycleService
    {
        private readonly IMongoCollection<Cycle> cycles;

        public CycleService(IMadbullDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            cycles = database.GetCollection<Cycle>(settings.CyclesCollectionName);
        }

        public List<Cycle> Get() => cycles.Find(cycle => true).ToList();

        public Cycle Get(string id) =>
            cycles.Find<Cycle>(cycle => cycle.Id == id).FirstOrDefault();

        public Cycle Create(Cycle cycle)
        {
            cycles.InsertOne(cycle);
            return cycle;
        }

        public void Update(string id, Cycle cycleIn) =>
            cycles.ReplaceOne(cycle => cycle.Id == id, cycleIn);

        public void Remove(Cycle cycleIn) =>
            cycles.DeleteOne(cycle => cycle.Id == cycleIn.Id);

        public void Remove(string id) =>
            cycles.DeleteOne(cycle => cycle.Id == id);
    }
}
