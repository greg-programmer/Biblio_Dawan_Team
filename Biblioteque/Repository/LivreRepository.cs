﻿using Biblioteque.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteque.Repository
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
                .Include("Genres")
                .Include("Auteurs")
                .Include("Image")
                .ToList();
        }
        public override Livre FindById(long id)
        {
            return context.Livres
                .Include("Genres")
                .Include("Auteurs")
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
