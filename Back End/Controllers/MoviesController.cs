using Back_End.Models;
using Back_End;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieUtility _utility;

        public MoviesController(MovieUtility utility)
        {
            _utility = utility;
        }

        [HttpGet("Movies")]
        public IActionResult Get()
        {
            var movies = _utility.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _utility.GetMovie(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost("AddMovie")]
        public IActionResult Post([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Movie data is null");
            }
            _utility.AddMovie(movie);
            return CreatedAtAction(nameof(Get), new { id = movie.MovieID }, movie);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingMovie = _utility.GetMovie(id);
            if (existingMovie == null)
            {
                return NotFound();
            }
            _utility.DeleteMovie(id);
            return NoContent();
        }
    }
}


