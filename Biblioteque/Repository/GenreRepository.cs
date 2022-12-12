using Biblioteque.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteque.Repository
{
    public class GenreRepository : Repository<Genre>
    {
        private BiblioContext Context;

        public GenreRepository(BiblioContext context) : base(context)
        {
            Context = context;
        }

        
    }
}
    