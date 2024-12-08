using CategoryMovie.API.Models;
using CategoryMovie.API.Repositorios;

namespace CategoryMovie.API.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;

    public MovieService(IMovieRepository repository)
    {
        _repository = repository;
    }

    public ProducerAwardsModel GetIntervaloPremios()
    {
        return _repository.AwardSearch();
    }
}
