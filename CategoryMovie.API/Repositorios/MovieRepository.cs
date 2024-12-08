using CategoryMovie.API.Data;
using CategoryMovie.API.Models;

namespace CategoryMovie.API.Repositorios;

public class MovieRepository : IMovieRepository
{
    private readonly MoviesContext _context;

    public MovieRepository(MoviesContext context)
    {
        _context = context;
    }

    public ProducerAwardsModel AwardSearch()
    {            
        var filmes = from films in _context.Movies.ToList()
                     where films.Winner
                     orderby films.Year
                     select films;

        var producerMinMax = new List<ProducerMinMax>();
        var max = 0;
        var min = 0;
        var firstInterval = 0;
        var gotFirstInterval = false;
  
        foreach (var a in filmes)
        {
            if (gotFirstInterval) break;

            foreach (var b in filmes)
            {
                int yearA = int.Parse(a.Year);
                int yearB = int.Parse(b.Year);

                if (a.Producers.ToUpper().Equals(b.Producers.ToUpper()) && yearA < yearB)
                {
                    firstInterval = yearB - yearA;
                    gotFirstInterval = true;
                    break;
                }
            }
        }
        
        foreach (var a in filmes)
        {
            foreach (var b in filmes)
            {
                int yearA = int.Parse(a.Year);
                int yearB = int.Parse(b.Year);

                if (a.Producers.ToUpper().Equals(b.Producers.ToUpper()) && yearA < yearB)
                {
                    var intervalo = yearB - yearA;
                
                    if (intervalo < firstInterval)
                    {
                        min = intervalo;
                    }

                    if (intervalo > max)
                    {
                        max = intervalo;
                    }

                    producerMinMax.Add(new ProducerMinMax
                    {
                        Producer = a.Producers,
                        Interval = intervalo,
                        PreviousWin = yearA,
                        FollowingWin = yearB
                    });
                }
            }
        }
       
        return new()
        {
            Min = producerMinMax.Where(intervalo => intervalo.Interval == min).ToList(),
            Max = producerMinMax.Where(intervalo => intervalo.Interval == max).ToList()
        };
    }
}
