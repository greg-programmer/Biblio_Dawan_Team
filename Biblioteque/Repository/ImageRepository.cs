using Biblioteque.Models;

namespace Biblioteque.Repository
{
    public class ImageRepository : Repository<Image>
    {
        private BiblioContext Context;
        public ImageRepository(BiblioContext context) : base(context)
        {
            Context = context; 
        }


    }
}
