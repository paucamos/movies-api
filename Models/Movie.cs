using System.Collections.Generic;
using System;

namespace Movies_Api.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string RatedId { get; set; } // 7+ years, 18+, etc
        public int Runtime { get; set; } // Minutes only

        //public int GenreId { get; set; } // TODO:: Create a Genre model LIST Nav Prop
        public string Director { get; set; }
        public string Writter { get; set; } // Separated by ;
        public List<MovieActor> Actors { get; set; } // Navigation property 
        public string Plot { get; set; }
        public string Languages { get; set; } // Create a table [to store "iso as id", "Spain"]
        public string Country { get; set; }
        public string Poster { get; set; } // Cover
    }
}