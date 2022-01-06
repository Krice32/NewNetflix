using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class FavoriteRepository
    {
        NewNetflixContext context;

        public FavoriteRepository()
        {
            context = new NewNetflixContext();
        }

        public Favorite Add(Favorite favorites)
        {
            context.Favorites.Add(favorites);
            context.SaveChanges();
            return favorites;
        }

        public bool Delete(int id)
        {
            var favorites = GetById(id);

            if (favorites.FavoritesId > 0)
            {
                context.Favorites.Remove(favorites);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public Favorite GetById(int id) => context.Favorites.Find(id);

        public Favorite Update(Favorite favorites)
        {
            var favoriteUp = GetById(favorites.FavoritesId);
            context.Entry(favoriteUp).CurrentValues.SetValues(favorites);
            context.SaveChanges();
            return favoriteUp;
        }

        public IEnumerable<Favorite> GetAll()
        {
            //select * from movies
            try
            {
                var result = context.Favorites
                   .Include(x => x.Mv)
                   .Include(y => y.Se)
                   .ThenInclude(y => y.UserWatches)
                   .ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"Erro : {ex.Message}");
                return Enumerable.Empty<Favorite>();

            }
        }
    }
}
