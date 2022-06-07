using System.Text.Json;
using RediAPI.Models;
using StackExchange.Redis;

namespace RediAPI.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;
        private readonly string HashKey = "PlatformHash";

        public PlatformRepo(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = redis.GetDatabase();

        }
        public async Task<Platform?> createPlatform(Platform platform)
        {
            // var serialized = JsonSerializer.Serialize(platform) ;
            // bool set = await _database.StringSetAsync(platform.Id,serialized) ;
            // if  (!set)
            // {
            //     return null ;
            // }
            // return platform ;



            var serialized = JsonSerializer.Serialize(platform);
            await _database.HashSetAsync(HashKey, new HashEntry[]{
                new HashEntry(platform.Id,serialized)
            });
            return platform;




        }

        public async Task<IEnumerable<Platform?>?> GetAll()
        {
            var platformHash = await _database.HashGetAllAsync(HashKey);
            if (platformHash.Length != 0)
            {
                var result = Array.ConvertAll(platformHash, val => JsonSerializer.Deserialize<Platform>(val.Value));
                return result;
            }
            return null;
        }

        public async Task<Platform?> GetById(string Id)
        {
            // var serialized = await _database.StringGetAsync(Id) ;
            // if(!string.IsNullOrEmpty(serialized))
            // {
            //     var platform = JsonSerializer.Deserialize<Platform>(serialized) ;
            //     return platform ;
            // }
            // return null ;


            var serializedPlat = await _database.HashGetAsync(HashKey, Id);
            var platform = JsonSerializer.Deserialize<Platform>(serializedPlat);
            return platform ;

        }
    }
}