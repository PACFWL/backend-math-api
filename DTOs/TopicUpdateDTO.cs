namespace backend_math_api.DTOs
{
    public class TopicUpdateDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<string> Examples { get; set; } = new();
        public string MathRepresentation { get; set; } = string.Empty;
        public string? VideoUrl { get; set; }
        public List<SubtopicDTO> Subtopics { get; set; } = new();
    }
}