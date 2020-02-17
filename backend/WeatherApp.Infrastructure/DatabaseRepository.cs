using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Weather.Utils.DatabaseSettings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Blog.Infrastructure
{
    public class DatabaseRepository
    {
        private readonly IMongoDatabase _database;
        
        public DatabaseRepository(IOptions<Settings> settingsOptions)
        {
            MongoDefaults.GuidRepresentation = MongoDB.Bson.GuidRepresentation.Standard;

            var client = new MongoClient(settingsOptions.Value.MongoDbConnection);
            _database = client.GetDatabase(settingsOptions.Value.MongoDatabaseName);
            
            BsonClassMap.RegisterClassMap<Weather.Models.Weather>(x => 
            {
                x.AutoMap();
                x.SetIgnoreExtraElements(true);
                x.MapIdMember(y => y.Name);
            });

            
        }

        private IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }

        public IQueryable<Weather.Models.Weather> GetWeatherData()
        {
            return GetCollection<Weather.Models.Weather>().AsQueryable();
        }

        
    }
}