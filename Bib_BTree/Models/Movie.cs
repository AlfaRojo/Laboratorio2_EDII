using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bib_BTree.Models
{
    public class Movie
    {
        public string director { get; set; }
        [Required]
        public double imdbRating { get; set; }
        [Required]
        public string genre { get; set; }
        [Required]
        public string releaseDate { get; set; }
        [Required]
        public int rottenTomatoesRating { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public int nombre_año { get; set; }

        public int CompareTo(object obj)
        {
            var movie2 = (Movie)obj;
            if (GetMax(title) > GetMax(movie2.title)) return 1;
            else if (GetMax(title) < GetMax(movie2.title)) return -1;
            else return (title.CompareTo(movie2.title));
        }

        public int GetMax(string title)
        {
            var u8 = Encoding.UTF8;
            var Result = u8.GetByteCount(title);
            return Result;
        }
    }
}
