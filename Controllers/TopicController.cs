using backend_math_api.Mappers;
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

        [HttpGet("{topicId}")]
        public async Task<ActionResult<TopicDTO>> GetTopic(string sectorId, string topicId)
        {
            var topic = await _service.GetTopicAsync(sectorId, topicId);
            if (topic is null) return NotFound();

            return TopicMapper.ToDTO(topic);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string sectorId, TopicCreateDTO dto)
        {
            var topic = TopicMapper.ToModel(dto);
            await _service.AddTopicAsync(sectorId, topic);

            return CreatedAtAction(nameof(GetTopic), new { sectorId, topicId = topic.Id }, TopicMapper.ToDTO(topic));
        }

        [HttpPut("{topicId}")]
        public async Task<IActionResult> Update(string sectorId, string topicId, TopicUpdateDTO dto)
        {
            var existing = await _service.GetTopicAsync(sectorId, topicId);
            if (existing is null) return NotFound();

            TopicMapper.UpdateModel(existing, dto);
            await _service.UpdateTopicAsync(sectorId, topicId, existing);

            return NoContent();
        }

        [HttpDelete("{topicId}")]
        public async Task<IActionResult> Delete(string sectorId, string topicId)
        {
            var existing = await _service.GetTopicAsync(sectorId, topicId);
            if (existing is null) return NotFound();

            await _service.DeleteTopicAsync(sectorId, topicId);
            return NoContent();
        }
    }
}
