using CategoryMovie.API.Data;
using CategoryMovie.API.Repositorios;
using CategoryMovie.API.Services;
using Microsoft.EntityFrameworkCore;

namespace CategoryMovie.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MoviesContext>(opt => opt.UseInMemoryDatabase("MoviesDb"));

            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IMovieService, MovieService>();

            builder.Services.AddControllers();           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
          
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            MovieCsvSeed.AppBuild(app);

            app.Run();
        }
    }
}

public partial class Program { }
