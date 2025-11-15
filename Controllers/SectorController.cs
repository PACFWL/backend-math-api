using backend_math_api.Models;
using backend_math_api.Services;
using Microsoft.AspNetCore.Mvc;
using backend_math_api.DTOs;
using backend_math_api.Mappers;

namespace backend_math_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorController : ControllerBase
    {
        private readonly SectorService _sectorService;

        public SectorController(SectorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sector>>> GetAll() =>
            await _sectorService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Sector>> GetById(string id)
        {
            var sector = await _sectorService.GetByIdAsync(id);
            if (sector is null) return NotFound();
            return sector;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SectorCreateDTO dto)
        {
            var sector = SectorMapper.ToModel(dto);

            await _sectorService.CreateAsync(sector);

            var sectorDto = SectorMapper.ToDTO(sector);

            return CreatedAtAction(nameof(GetById), new { id = sector.Id }, sectorDto);
        }

    }  
}