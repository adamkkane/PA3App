using Back_End.Models;
using Back_End;
using Microsoft.AspNetCore.Mvc;


namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
       

        private readonly string _connectionString;

        public MoviesController(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        // GET: api/Team
        [Route("Movies")]
        [HttpGet]
        public List<Movie> Get()
        {
                MovieUtility utility = new MovieUtility();
                return utility.GetAllMovies();
        }
 
        [Route("{id}")]
        [HttpGet]
        public Movie Get(int id)
        {
            MovieUtility utility = new MovieUtility();
            List<Movie> myMovies = utility.GetAllMovies();
            foreach(Movie movie in myMovies)
            {
                if(movie.MovieID == id)
                {
                    return movie;
                }
            }
            return new Movie();
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

