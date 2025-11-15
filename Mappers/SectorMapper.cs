using backend_math_api.Models;
using backend_math_api.DTOs;
using System.Linq;

namespace backend_math_api.Mappers
{
    public static class SectorMapper
    {
        
        public static Sector ToModel(SectorCreateDTO dto) =>
            new Sector
            {
                Name = dto.Name,
                Description = dto.Description
            };

        
        public static SectorDTO ToDTO(Sector model) =>
            new SectorDTO
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };
    }
}
