using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class GenreRepository : Repository<Genre>
    {
        protected BiblioContext Context;

        public GenreRepository(BiblioContext context) : base(context)
        {
            Context = context;
        }
    }
}
