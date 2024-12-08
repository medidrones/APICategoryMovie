using CategoryMovie.API.Models;

namespace CategoryMovie.API.Repositorios;

public interface IMovieRepository
{
    ProducerAwardsModel AwardSearch();
}
