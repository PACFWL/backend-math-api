using backend_math_api.Models;

namespace backend_math_api.Repositories
{
    public interface ITopicRepository
    {
        Task<List<Topic>> GetTopicsBySectorAsync(string sectorId);
        Task<Topic?> GetTopicByIdAsync(string sectorId, string topicTitle);
        Task AddTopicAsync(string sectorId, Topic topic);
        Task UpdateTopicAsync(string sectorId, string oldTitle, Topic updatedTopic);
        Task DeleteTopicAsync(string sectorId, string topicTitle);
    }
}
