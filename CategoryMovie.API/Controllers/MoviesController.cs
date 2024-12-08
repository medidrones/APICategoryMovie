using CategoryMovie.API.Models;
using CategoryMovie.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CategoryMovie.API.Controllers;

[Route("[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{ 
    [HttpGet]
    public ProducerAwardsModel Get([FromServices] IMovieService moviesService)
    {
        return moviesService.GetIntervaloPremios();
    }
}
