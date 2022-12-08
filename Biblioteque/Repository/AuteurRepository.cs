using Biblioteque.Models;

namespace Biblioteque.Repository
{
    public class AuteurRepository : Repository<Auteur>
    {
        private BiblioContext Context;
        public AuteurRepository(BiblioContext context) : base(context)
        {
            this.Context = context;
        }

    }
}
