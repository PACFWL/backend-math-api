namespace backend_math_api.Models
{
    public class Topic
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<string> Examples { get; set; } = new();
        public string MathRepresentation { get; set; } = string.Empty;
        public string? VideoUrl { get; set; }
        public List<Subtopic> Subtopics { get; set; } = new();
    }
}