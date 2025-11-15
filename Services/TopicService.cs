using backend_math_api.Models;
using MongoDB.Driver;

namespace backend_math_api.Services
{
    public class TopicService
    {
        private readonly IMongoCollection<Sector> _sectors;

        public TopicService(IConfiguration config)
        {
            var client = new MongoClient(config["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(config["DatabaseSettings:DatabaseName"]);
            _sectors = database.GetCollection<Sector>("Sectors");
        }

        public async Task<List<Topic>> GetTopicsBySectorIdAsync(string sectorId)
        {
            var sector = await _sectors.Find(s => s.Id == sectorId).FirstOrDefaultAsync();
            return sector?.Topics ?? new List<Topic>();
        }

        public async Task AddTopicToSectorAsync(string sectorId, Topic newTopic)
        {
            var update = Builders<Sector>.Update.Push(s => s.Topics, newTopic);
            await _sectors.UpdateOneAsync(s => s.Id == sectorId, update);
        }
    }
}
