using CategoryMovie.API.Models;

namespace CategoryMovie.API.Data;

public static class MovieCsvSeed
{
    public static void AppBuild(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedMovies(serviceScope.ServiceProvider.GetService<MoviesContext>());
        }
    }

    public static List<MovieModel> SeedMovies(MoviesContext? context)
    {
        var movieAwardsPerProducer = new List<MovieModel>();

        //alterar para caminho onde está o arquivo
        var reader = new StreamReader(File.OpenRead(@"C:\Users\Jorge\Downloads\movielist.csv"));       

        var line = reader.ReadLine();
        var values = line.Split(';');

        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();
            values = line.Split(';');

            var producers = values[3].Replace(" and ", ",").Split(',');

            foreach (var producer in producers)
            {
                movieAwardsPerProducer.Add(
                    new MovieModel()
                    {
                        Year = values[0],
                        Title = values[1],
                        Studios = values[2],
                        Producers = producer.Trim(),
                        Winner = !string.IsNullOrWhiteSpace(values[4])
                    });
            }
        }

        context.Movies.AddRange(movieAwardsPerProducer);

        context.SaveChanges();

        return movieAwardsPerProducer;
    }
}
