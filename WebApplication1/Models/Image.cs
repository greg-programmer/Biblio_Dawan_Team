using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Image : AbstractEntity
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Extension { get; set; }
        public string Type_Image { get; set; }
    }
}
