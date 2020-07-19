using System;
using MadbullAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MadbullAPI.Tests.Integration
{
    public class DbFixture : IDisposable
    {
        public DbFixture()
        {
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build()
                .GetSection("MadbullDatabaseSettings")
                .Bind(DbSettings);

            DbSettings.DatabaseName = $"test_db_{ Guid.NewGuid() }";
        }

        public IMadbullDatabaseSettings DbSettings { get; } = new MadbullDatabaseSettings();

        public void Dispose()
        {
            var client = new MongoClient(DbSettings.ConnectionString);
            client.DropDatabase(DbSettings.DatabaseName);
        }
    }
}
