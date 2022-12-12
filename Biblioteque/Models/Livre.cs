namespace Biblioteque.Models
{
    public class Livre : AbstractEntity
    {
        public string ?Titre { get; set; }
        public DateTime Date_Parution { get; set; }
        public string ?Synopsis { get; set; }
        public enum Type_Livre 
        {
            Bande_dessine,
            Magazine,
            Roman,
            Biographie,
            Manga
        }
        public List<GenreLivre> ?GenreLivres { get; set; }
        public List<AuteurLivre> ?AuteurLivres { get; set; }
        public Image ?Image { get; set; }
    }
}
