using backend_math_api.Models;
using backend_math_api.DTOs;

public static class TopicMapper
{
    public static Topic ToModel(TopicCreateDTO dto) =>
        new()
        {
            Title = dto.Title,
            Content = dto.Content,
            Examples = dto.Examples,
            MathRepresentation = dto.MathRepresentation,
            VideoUrl = dto.VideoUrl,
            Subtopics = dto.Subtopics.Select(s => new Subtopic
            {
                Title = s.Title,
                Content = s.Content
            }).ToList()
        };

    public static TopicDTO ToDTO(Topic model) =>
        new()
        {
            Title = model.Title,
            Content = model.Content,
            Examples = model.Examples,
            MathRepresentation = model.MathRepresentation,
            VideoUrl = model.VideoUrl,
            Subtopics = model.Subtopics.Select(s => new SubtopicDTO
            {
                Title = s.Title,
                Content = s.Content
            }).ToList()
        };
}