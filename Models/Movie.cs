namespace Movies_Api.Models
{
    public class Movie
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string RatedId { get; set; } // 7+ years, 18+, etc
        public int Runtime { get; set; } // Minutes only
        public int GenreId { get; set; } // TODO:: Create a Genre model
        public string Director { get; set; }
        public string Writter { get; set; } // Separated by ;
        public string ActorsId { get; set; } // Separated by ;
        public string Plot { get; set; }
        public string Languages { get; set; } // Separated by ;
        public string Country { get; set; }
        public string Poster { get; set; } // Cover
    }
}