﻿using Biblioteque.Models;

namespace Biblioteque.Services
{
    public interface IServices
    {
        public void FavoriteBook(bool heart, List<Livre> livrelist, long id);
    }
}
