var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("api/", () => "Hello cinepass");

app.UseHttpsRedirection();

app.Run();