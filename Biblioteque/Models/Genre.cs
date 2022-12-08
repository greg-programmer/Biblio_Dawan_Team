using System.ComponentModel.DataAnnotations;

namespace Biblioteque.Models
{
    public class Genre : AbstractEntity
    {
        [Required]
        public string Nom { get; set; }

        public List<GenreLivre> GenreLivres { get; set; }
    }
}
