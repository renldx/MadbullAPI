using MongoDB.Driver;
using MadbullAPI.Models;

namespace MadbullAPI.Services
{
    public abstract class BaseService
    {
        protected MongoClient client;
        protected IMongoDatabase database;

        public BaseService(IMadbullDatabaseSettings settings)
        {
            client = new MongoClient(settings.ConnectionString);
            database = client.GetDatabase(settings.DatabaseName);
        }
    }
}
