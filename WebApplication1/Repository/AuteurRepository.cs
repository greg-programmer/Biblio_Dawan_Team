using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class AuteurRepository : Repository<Auteur>
    {
        private BiblioContext Context;
        public AuteurRepository(BiblioContext context) : base(context)
        {
            Context = context;
        }

    }
}
