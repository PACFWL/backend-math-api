using backend_math_api.Models;

namespace backend_math_api.Repositories
{
    public interface ISectorRepository
    {
        Task<List<Sector>> GetAllAsync();
        Task<Sector?> GetByIdAsync(string id);
        Task CreateAsync(Sector newSector);
        Task UpdateAsync(string id, Sector updatedSector);
        Task DeleteAsync(string id);
    }
}
