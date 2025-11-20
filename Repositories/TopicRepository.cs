using backend_math_api.Models;
using MongoDB.Driver;

namespace backend_math_api.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly IMongoCollection<Sector> _sectors;

        public TopicRepository(IConfiguration config)
        {
            var client = new MongoClient(config["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(config["DatabaseSettings:DatabaseName"]);
            _sectors = database.GetCollection<Sector>("Sectors");
        }

        public async Task<List<Topic>> GetTopicsBySectorAsync(string sectorId)
        {
            var sector = await _sectors.Find(s => s.Id == sectorId).FirstOrDefaultAsync();
            return sector?.Topics ?? new List<Topic>();
        }

        public async Task<Topic?> GetTopicByIdAsync(string sectorId, string topicId)
        {
            var sector = await _sectors.Find(s => s.Id == sectorId).FirstOrDefaultAsync();
            return sector?.Topics.FirstOrDefault(t => t.Id == topicId);
        }

        public async Task AddTopicAsync(string sectorId, Topic topic)
        {
            var update = Builders<Sector>.Update.Push(s => s.Topics, topic);
            await _sectors.UpdateOneAsync(s => s.Id == sectorId, update);
        }

        public async Task UpdateTopicAsync(string sectorId, string topicId, Topic updatedTopic)
        {
            var filter = Builders<Sector>.Filter.And(
                Builders<Sector>.Filter.Eq(s => s.Id, sectorId),
                Builders<Sector>.Filter.Eq("Topics.Id", topicId)
            );

            var update = Builders<Sector>.Update.Set("Topics.$", updatedTopic);

            await _sectors.UpdateOneAsync(filter, update);
        }

        public async Task DeleteTopicAsync(string sectorId, string topicId)
        {
            var update = Builders<Sector>.Update.PullFilter(
                s => s.Topics,
                t => t.Id == topicId
            );

            await _sectors.UpdateOneAsync(s => s.Id == sectorId, update);
        }
    }
}
