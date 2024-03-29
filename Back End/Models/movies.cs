using NuGet.Protocol.Plugins;

namespace Back_End.Models{

public class Movie
{
    public int MovieID{get; set;}
    public string MovieName{get; set;}
    public int MovieRating{get; set;}
    public string MovieReleaseDate{get; set;}

    public override string ToString()
    {
        return MovieID + " " + MovieName + " " + MovieRating + " " + MovieReleaseDate;
    }
}
}