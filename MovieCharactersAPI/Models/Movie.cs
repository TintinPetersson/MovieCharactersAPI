using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace MovieCharactersAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string Title { get; set; }
        [MaxLength(100)]
        //Genre(just a simple string of comma separated genres, there is no genre modelling required as a base)
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        [MaxLength(40)]
        public string Director { get; set; }
   
        public string Picture { get; set; }
        
        public string Trailer { get; set; }
        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
        public List<Character> Characters { get; set;}
    }
}
