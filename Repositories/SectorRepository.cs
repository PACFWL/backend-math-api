using backend_math_api.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace backend_math_api.Repositories
{
    public class SectorRepository : ISectorRepository
    {
        private readonly IMongoCollection<Sector> _sectors;

        public SectorRepository(IConfiguration config)
        {
            var client = new MongoClient(config["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(config["DatabaseSettings:DatabaseName"]);
            _sectors = database.GetCollection<Sector>("Sectors");
        }

        public async Task<List<Sector>> GetAllAsync() =>
            await _sectors.Find(_ => true).ToListAsync();

        public async Task<Sector?> GetByIdAsync(string id) =>
            await _sectors.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Sector newSector) =>
            await _sectors.InsertOneAsync(newSector);

        public async Task UpdateAsync(string id, Sector updatedSector) =>
            await _sectors.ReplaceOneAsync(x => x.Id == id, updatedSector);

        public async Task DeleteAsync(string id) =>
            await _sectors.DeleteOneAsync(x => x.Id == id);
    }
}
