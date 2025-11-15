using backend_math_api.Models;
using backend_math_api.Services;
using Microsoft.AspNetCore.Mvc;
using backend_math_api.DTOs;

namespace backend_math_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly TopicService _topicService;

        public TopicController(TopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet("{sectorId}")]
        public async Task<ActionResult<List<TopicDTO>>> GetTopicsBySector(string sectorId)
        {
            var topics = await _topicService.GetTopicsBySectorIdAsync(sectorId);

            if (topics.Count == 0)
                return NotFound("Nenhum tópico encontrado.");

            return topics.Select(TopicMapper.ToDTO).ToList();
        }

        [HttpPost("{sectorId}")]
        public async Task<IActionResult> AddTopic(string sectorId, [FromBody] TopicCreateDTO dto)
        {
            var topic = TopicMapper.ToModel(dto);

            await _topicService.AddTopicToSectorAsync(sectorId, topic);

            return Ok("Tópico adicionado.");
        }
    }
}
