<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
=======
﻿using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> c9e229e602811744bac6ab818b33cfafad51d15e

namespace Biblioteque.Models
{
    public class Livre : AbstractEntity
    {
        [Required (ErrorMessage ="Quel est le titre du livre ?")]
        [Display(Name = "Titre du livre")]      
        public string ?Titre { get; set; }
        [Display(Name = "Date de parution")]
        public DateTime ?Date_Parution { get; set; }
<<<<<<< HEAD
        [Required(ErrorMessage ="Un résumé vous aidera à attirer le lecteur !")]
        [MaxLength(200)]
        [Display(Name = "Résumer du livre ...(200 caractères maximum)")]
        public string ?Synopsis { get; set; }       
      
=======

        [MaxLength(500)]
        public string ?Synopsis { get; set; }

>>>>>>> c9e229e602811744bac6ab818b33cfafad51d15e
        public enum Type_Livre 
        {
            Bande_dessine,
            Magazine,
            Roman,
            Biographie,
            Manga
        }

<<<<<<< HEAD
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-\(\):])+(.jpeg|.jpg|.gif|"")$",
            ErrorMessage = "Format autorisés : jpeg, jpg, gif.")]
        [NotMapped]       
        public IFormFile?Image { get; set; }      
=======
        [NotMapped]
        public IFormFile ?Image { get; set; }
  
>>>>>>> c9e229e602811744bac6ab818b33cfafad51d15e
        public string ?CheminImage { get; set; }
        public ICollection<Genre> ?Genres { get; set; }
        public ICollection<Auteur> ?Auteurs { get; set; }
        public bool CoupDeCoeur { get; set; }= false;
        
    }
}
