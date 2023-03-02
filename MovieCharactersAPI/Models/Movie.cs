using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace MovieCharactersAPI.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Characters = new List<Character>();
        }
        public int Id { get; set; }
        [MaxLength(40)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        [MaxLength(40)]
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
        public int? FranchiseId { get; set; }
        public virtual Franchise? Franchise { get; set; }
        public virtual ICollection<Character> Characters { get; set;}
    }
}
