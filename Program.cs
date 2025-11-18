using backend_math_api.Repositories;
using backend_math_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Repositórios
builder.Services.AddSingleton<ISectorRepository, SectorRepository>();
builder.Services.AddSingleton<ITopicRepository, TopicRepository>();

// Services
builder.Services.AddSingleton<SectorService>();
builder.Services.AddSingleton<TopicService>(); 

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Controllers
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowFrontend");
app.MapControllers();

app.MapGet("/", () => "✅ ");
app.MapGet("/ping", () => "🏓 Pong! Servidor ativo.");

app.Run();
