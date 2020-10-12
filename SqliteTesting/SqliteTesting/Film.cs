using System.ComponentModel.DataAnnotations;

namespace SqliteTesting
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public Film(int filmId, string name, string genre)
        {
            FilmId = filmId;
            Name = name;
            Genre = genre;
        }

        public Film()
        {
            
        }
    }
}