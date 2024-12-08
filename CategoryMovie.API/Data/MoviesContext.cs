using CategoryMovie.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoryMovie.API.Data;

public class MoviesContext : DbContext
{
    public MoviesContext(DbContextOptions options) : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "MoviesDb");
    }

    public DbSet<MovieModel> Movies { get; set; }
}
