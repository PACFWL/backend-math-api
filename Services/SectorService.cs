using backend_math_api.Models;
using backend_math_api.Repositories;

namespace backend_math_api.Services
{
    public class SectorService
    {
        private readonly ISectorRepository _repository;

        public SectorService(ISectorRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Sector>> GetAllAsync() =>
            _repository.GetAllAsync();

        public Task<Sector?> GetByIdAsync(string id) =>
            _repository.GetByIdAsync(id);

        public Task CreateAsync(Sector newSector) =>
            _repository.CreateAsync(newSector);

        public Task UpdateAsync(string id, Sector updatedSector) =>
            _repository.UpdateAsync(id, updatedSector);

        public Task DeleteAsync(string id) =>
            _repository.DeleteAsync(id);
    }
}
