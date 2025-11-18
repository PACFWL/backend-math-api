using backend_math_api.Models;
using backend_math_api.Repositories;

namespace backend_math_api.Services
{
    public class TopicService
    {
        private readonly ITopicRepository _repository;

        public TopicService(ITopicRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Topic>> GetTopicsBySectorIdAsync(string sectorId) =>
            _repository.GetTopicsBySectorAsync(sectorId);

        public Task<Topic?> GetTopicAsync(string sectorId, string title) =>
            _repository.GetTopicByIdAsync(sectorId, title);

        public Task AddTopicAsync(string sectorId, Topic topic) =>
            _repository.AddTopicAsync(sectorId, topic);

        public Task UpdateTopicAsync(string sectorId, string oldTitle, Topic updated) =>
            _repository.UpdateTopicAsync(sectorId, oldTitle, updated);

        public Task DeleteTopicAsync(string sectorId, string title) =>
            _repository.DeleteTopicAsync(sectorId, title);
    }
}
