using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Utils.DatabaseSettings;
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
            
            BsonClassMap.RegisterClassMap<Blog.Models.Blog>(x => 
            {
                x.AutoMap();
                x.SetIgnoreExtraElements(true);
                x.MapIdMember(y => y.Id);
            });

            BsonClassMap.RegisterClassMap<Author>(x => 
            {
                x.AutoMap();
                x.SetIgnoreExtraElements(true);
            });
            
            BsonClassMap.RegisterClassMap<Post>(x => 
            {
                x.AutoMap();
                x.SetIgnoreExtraElements(true);
            });
        }

        private IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }

        public IQueryable<Blog.Models.Blog> GetBlogData()
        {
            return GetCollection<Blog.Models.Blog>().AsQueryable();
        }

        public async Task Insert<T>(T value)
        {
            await GetCollection<T>().InsertOneAsync(value);
        }

        public async Task Update<T>(Expression<Func<T, bool>> predicate, T value)
        {
            await GetCollection<T>().ReplaceOneAsync(predicate, value);
        }

        public async Task Delete<T>(Expression<Func<T, bool>> predicate)
        {
            await GetCollection<T>().DeleteOneAsync(predicate);
        }
    }
}