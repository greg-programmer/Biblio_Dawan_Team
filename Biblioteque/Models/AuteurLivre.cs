namespace Biblioteque.Models
{
    public class AuteurLivre
    {
        public long Auteur_Id { get; set; }
        public long Livre_Id { get; set; }
        public Livre Livres { get; set; }
        public Auteur Auteurs { get; set; }
    }
}
