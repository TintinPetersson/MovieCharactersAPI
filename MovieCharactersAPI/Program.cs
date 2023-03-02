using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Services.Movies;
using System.Reflection;

// Create the Web application
var builder = WebApplication.CreateBuilder(args);

var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);


// Add services to the container (Dependences injection).
builder.Services.AddControllers();
builder.Services.AddDbContext<MovieCharactersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MovieCharacters API",
        Description = "API Contains information about movies and was made by:\nFilip Lindell & Tintin Petersson",
        Contact = new OpenApiContact
        {
            Name = "Github repo",
            Url = new Uri("https://github.com/TintinPetersson/MovieCharactersAPI")
        },
        License = new OpenApiLicense
        {
            Name = "MIT 2022",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adding logging through ILogger
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});


// Build the web application with all the dependences
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
