using backend_math_api.Models;
using backend_math_api.Services;
using Microsoft.AspNetCore.Mvc;
using backend_math_api.DTOs;

namespace backend_math_api.Controllers
{
    [ApiController]
    [Route("api/sectors/{sectorId}/topics")]
    public class TopicController : ControllerBase
    {
        private readonly TopicService _service;

        public TopicController(TopicService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TopicDTO>>> GetTopics(string sectorId)
        {
            var topics = await _service.GetTopicsBySectorIdAsync(sectorId);
            return topics.Select(TopicMapper.ToDTO).ToList();
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<TopicDTO>> GetTopic(string sectorId, string title)
        {
            var topic = await _service.GetTopicAsync(sectorId, title);
            if (topic is null) return NotFound();

            return TopicMapper.ToDTO(topic);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string sectorId, TopicCreateDTO dto)
        {
            var topic = TopicMapper.ToModel(dto);
            await _service.AddTopicAsync(sectorId, topic);

            return CreatedAtAction(nameof(GetTopic), new { sectorId, title = topic.Title }, TopicMapper.ToDTO(topic));
        }

        [HttpPut("{oldTitle}")]
        public async Task<IActionResult> Update(string sectorId, string oldTitle, TopicUpdateDTO dto)
        {
            var existing = await _service.GetTopicAsync(sectorId, oldTitle);
            if (existing is null) return NotFound();

            TopicMapper.UpdateModel(existing, dto);
            await _service.UpdateTopicAsync(sectorId, oldTitle, existing);

            return NoContent();
        }

        [HttpDelete("{title}")]
        public async Task<IActionResult> Delete(string sectorId, string title)
        {
            await _service.DeleteTopicAsync(sectorId, title);
            return NoContent();
        }
    }
}
