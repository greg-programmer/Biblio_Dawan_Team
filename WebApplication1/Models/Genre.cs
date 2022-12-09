using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Genre : AbstractEntity
    {
        [Required]
        public string Nom { get; set; }

        public List<GenreLivre> GenreLivres { get; set; }
    }
}
