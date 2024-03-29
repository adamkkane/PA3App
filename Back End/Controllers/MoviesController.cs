using Back_End.Models;
using Back_End.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IGetAllMovies _getAllMovies;
        private readonly IGetMovie _getMovie;

        public MoviesController(IGetAllMovies getAllMovies, IGetMovie getMovie)
        {
            _getAllMovies = getAllMovies;
            _getMovie = getMovie;
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<Models.Movie> Get()
        {
            // Call GetAllMovies method to retrieve all movies
            return _getAllMovies.GetAllMovies();
        }

        // GET: api/Movies/5
        [HttpGet("{MovieID}", Name = "Get")]
        public ActionResult<Models.Movie> Get(int MovieID)
        {
            // Call GetMovie method to retrieve a movie by its ID
            var movie = _getMovie.GetMovie(MovieID);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        // POST: api/Movies
        [HttpPost]
        public void Post([FromBody] string value)
        {
  
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
  
        }
    }
}

