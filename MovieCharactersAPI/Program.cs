using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Services;

// Create the Web application
var builder = WebApplication.CreateBuilder(args);

// Add services to the container (Dependences injection).
builder.Services.AddControllers();
builder.Services.AddDbContext<MovieCharactersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

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
