using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteque.Models
{
    public class Livre : AbstractEntity
    {
        public string ?Titre { get; set; }
        public DateTime ?Date_Parution { get; set; }

        [MaxLength(500)]
        public string ?Synopsis { get; set; }

        public enum Type_Livre 
        {
            Bande_dessine,
            Magazine,
            Roman,
            Biographie,
            Manga
        }

        [NotMapped]
        public IFormFile ?Image { get; set; }
  
        public string ?CheminImage { get; set; }
        public ICollection<Genre> ?Genres { get; set; }
        public ICollection<Auteur> ?Auteurs { get; set; }

        
    }
}
