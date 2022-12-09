using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class LivreRepository : Repository<Livre>
    {
        private BiblioContext Context;

        public LivreRepository(BiblioContext context) : base(context)
        {
            Context = context;
        }
        public override List<Livre> FindAll()
        {
            return context.Livres
                .Include("GenreLivre")
                .Include("AuteurLivre")
                .Include("Image")
                .ToList();
        }
        public override Livre FindById(long id)
        {
            return context.Livres
                .Include("GenreLivre")
                .Include("AuteurLivre")
                .Include("Image")
                .FirstOrDefault(x => x.Id == id);
        }

        /* public override void Delete(long id)
         {
             ImageRepository imgRep = new ImageRepository(Context);
             Livre livre = FindById(id);
             Image img = livre.Image;
             imgRep.Delete(img.Id);
             base.Delete(id);            
         }*/
    }
}
