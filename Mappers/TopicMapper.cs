using backend_math_api.Models;
using backend_math_api.DTOs;

public static class TopicMapper
{
    public static Topic ToModel(TopicCreateDTO dto) =>
        new Topic
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

    public static void UpdateModel(Topic model, TopicUpdateDTO dto)
    {
        model.Title = dto.Title;
        model.Content = dto.Content;
        model.Examples = dto.Examples;
        model.MathRepresentation = dto.MathRepresentation;
        model.VideoUrl = dto.VideoUrl;
        model.Subtopics = dto.Subtopics.Select(s => new Subtopic
        {
            Title = s.Title,
            Content = s.Content
        }).ToList();
    }

    public static TopicDTO ToDTO(Topic model) =>
        new TopicDTO
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
