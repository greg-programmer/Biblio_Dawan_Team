using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
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
