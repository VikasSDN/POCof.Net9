using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesDemo.Core.Entities
{
    public class MoviesEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string Title { get; set; }

        public DateTime ReleaseYear { get; set; }

        public required string posterImagePath { get; set; }
    }
}
