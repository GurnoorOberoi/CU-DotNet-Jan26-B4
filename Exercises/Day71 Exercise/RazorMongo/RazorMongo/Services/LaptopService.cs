using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RazorMongo.Models;
using RazorMongo.MongoDBSettings;

namespace RazorMongo.Services
{
    public class LaptopService
    {
        private readonly IMongoCollection<Laptop> _laptops;

        public LaptopService(IOptions<MongoDBSetting> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _laptops = database.GetCollection<Laptop>(settings.Value.CollectionName);
        }

        // CREATE
        public async Task CreateAsync(Laptop laptop)
        {
            await _laptops.InsertOneAsync(laptop);
        }

        // READ
        public async Task<List<Laptop>> GetAsync()
        {
            return await _laptops.Find(_ => true).ToListAsync();
        }
    }
}
