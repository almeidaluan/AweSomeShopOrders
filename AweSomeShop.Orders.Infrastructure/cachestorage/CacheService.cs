using AweSomeShop.Orders.Core.interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace AweSomeShop.Orders.Infrastructure.cachestorage
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache distributedCache;
        public CacheService(IDistributedCache distributedCache){
            this.distributedCache = distributedCache;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var objectString = await distributedCache.GetStringAsync(key);

            if(string.IsNullOrWhiteSpace(objectString)){
                Console.WriteLine("Cache key not found");
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(objectString);
        }

        public async Task SetAsync<T>(string key, T data)
        {
            var memoryCacheEntryOptions = new DistributedCacheEntryOptions{
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600), //Vai cachear por X tempo dps morre
                SlidingExpiration = TimeSpan.FromSeconds(1200) // Vai ficar cacheado por X tempo se ninguem buscar o dado em X tempo ele morre tbm
            };

            var objectString = JsonConvert.SerializeObject(data);

            await distributedCache.SetStringAsync(key,objectString,memoryCacheEntryOptions);

        }
    }
}