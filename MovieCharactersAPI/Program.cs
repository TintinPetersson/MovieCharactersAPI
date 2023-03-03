using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Services.Characters;
using MovieCharactersAPI.Services.Franchises;
using MovieCharactersAPI.Services.Movies;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

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
builder.Services.AddTransient<ICharacterService, CharacterService>();
builder.Services.AddTransient<IFranchiseService, FranchiseService>();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();