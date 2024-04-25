namespace Back_End.Models
{
    public class Movie
    {
        public int MovieID { get; set; } // Assuming this is the primary key
        public string MovieName { get; set; } // Changed to varchar(255)
        public int MovieRating { get; set; }
        public DateTime MovieReleaseDate { get; set; } // Changed to date
    }
}
