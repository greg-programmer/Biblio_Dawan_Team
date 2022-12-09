namespace WebApplication1.Models
{
    public class GenreLivre
    {
        public long Livre_Id { get; set; }
        public long Genre_Id { get; set; }
        public Genre Genres { get; set; }
        public Livre Livres { get; set; }
    }
}
