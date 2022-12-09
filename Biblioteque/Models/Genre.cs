using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Biblioteque.Models
{
    public class Genre : AbstractEntity
    {
        [Required]
        public string ?Nom { get; set; }

        // le "?" permet d'indiquer que le champs peut être null
        public List<GenreLivre> ?GenreLivres { get; set; }
    }
}
