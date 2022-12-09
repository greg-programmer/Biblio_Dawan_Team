using System.ComponentModel.DataAnnotations;

namespace Biblioteque.Models
{
    public class Auteur : AbstractEntity
    {
        [Required]
        public string ?Nom { get; set; }
        [Required]
        public string ?Prenom { get; set; }
        [Required]
        public DateTime Date_Naissance { get; set; }
        public DateTime Date_Mort { get; set; }

        public List<AuteurLivre> ?AuteurLivres { get; set; }
    }
}
