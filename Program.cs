using backend_math_api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SectorService>();
builder.Services.AddSingleton<TopicService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowFrontend");
app.MapControllers();

app.MapGet("/", () => "✅ ");
app.MapGet("/ping", () => "🏓 Pong! Servidor ativo.");

app.Run();
