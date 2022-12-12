using System.ComponentModel.DataAnnotations;

namespace Biblioteque.Models
{
    public class Image : AbstractEntity
    {
        [Required]
        public string ?Nom { get; set; }
        [Required]
        public string ?Extension { get; set; }
        public string ?Type_Image { get; set; }
    }
}
