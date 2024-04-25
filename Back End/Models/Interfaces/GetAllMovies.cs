using MySqlConnector;

namespace Back_End.Models.Interfaces
{

    public interface IGetAllMovies
    {
        List<Movie> GetAllMovies();
    }

    public class GetAllMoviesMySQL : IGetAllMovies
    {
        public List<Movie> GetAllMovies()
        {
            List<Movie> allMovies = new List<Movie>();

            // MySQL connection string
            string server = "q3vtafztappqbpzn.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "gtjytuh7vzr4bzmq";
            string port = "3306";
            string username = "w9qo8tyo6puecu82";
            string password = "wecn50qrwml1n2l0";


            // MySQL connection string
            string connectionString = $@"server={server};user={username};database={database};port={port};password={password};";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Movies;";
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
