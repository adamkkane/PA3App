using Back_End.Models.Interfaces;
using MySqlConnector;


namespace Back_End.Models
{
    public class ReadMovieData : IGetAllMovies, IGetMovie
    {
        // Implement GetMovie method to retrieve a movie by its ID
        public Movie GetMovie(int MovieId)
        {
            // Your implementation logic to fetch movie by ID from the database
            throw new NotImplementedException();
        }

        // Implement GetAllMovies method to retrieve all movies
        public List<Movie> GetAllMovies()
        {
            List<Movie> allMovies = new List<Movie>();

            // MySQL connection string
            string connectionString = "server=localhost;database=gtjytuh7vzr4bzmq;uid=w9qo8tyo6puecu82;password=wecn50qrwml1n2l0;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Movies";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allMovies.Add(new Movie()
                            {
                                MovieID = reader.GetInt32(0),
                                MovieName = reader.GetString(1),
                                MovieRating = reader.GetInt32(2),
                                MovieReleaseDate = reader.GetString(3)
                            });
                        }
                    }
                }
            }

            return allMovies;
        }
    }
}
