using Back_End.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace Back_End
{
    public class MovieUtility 
    {
        public void AddMovie(Movie movie)
        {
            Database db = new Database();
            using var con = new MySqlConnection(db.cs);
            con.Open();
 
            string stm = @"INSERT INTO Movies(MovieName, MovieRating, MovieReleaseDate)
                           VALUES(@movie_name, @movie_rating, @release_date)";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@movie_name", movie.MovieName);
            cmd.Parameters.AddWithValue("@movie_rating", movie.MovieRating);
            cmd.Parameters.AddWithValue("@release_date", movie.MovieReleaseDate);
 
            cmd.ExecuteNonQuery();
        }
 
        public List<Movie> GetAllMovies()
        {
            Database db = new Database();
            using var con = new MySqlConnection(db.cs);
            con.Open();
            List<Movie> myMovies = new List<Movie>();
            string stm = "SELECT * FROM Movies";
            using var cmd = new MySqlCommand(stm, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Movie movie = new Movie
                {
                    MovieID = rdr.GetInt32(0),
                    MovieName = rdr.GetString(1),
                    MovieRating = rdr.GetInt32(2),
                    MovieReleaseDate = rdr.GetDateTime(3)
                };
                myMovies.Add(movie);
            }
            return myMovies;
        }
        
        public Movie GetMovie(int movieID)
        {
            Database db = new Database();
            using var con = new MySqlConnection(db.cs);
            con.Open();
            string stm = "SELECT * FROM Movies WHERE MovieID = @movie_id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@movie_id", movieID);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                Movie movie = new Movie
                {
                    MovieID = rdr.GetInt32(0),
                    MovieName = rdr.GetString(1),
                    MovieRating = rdr.GetInt32(2),
                    MovieReleaseDate = rdr.GetDateTime(3)
                };
                return movie;
            }
            return null; // Movie not found
        }

        public void EditMovie(int movieID, Movie movie)
        {
            Database db = new Database();
            using var con = new MySqlConnection(db.cs);
            con.Open();
            string stm = @"UPDATE Movies SET MovieName = @movie_name, 
                           MovieRating = @movie_rating, MovieReleaseDate = @release_date 
                           WHERE MovieID = @movie_id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@movie_id", movieID);
            cmd.Parameters.AddWithValue("@movie_name", movie.MovieName);
            cmd.Parameters.AddWithValue("@movie_rating", movie.MovieRating);
            cmd.Parameters.AddWithValue("@release_date", movie.MovieReleaseDate);
            cmd.ExecuteNonQuery();
        }      
    }
}
