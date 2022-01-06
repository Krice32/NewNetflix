using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class WatchLaterRepository
    {
        NewNetflixContext context;

        public WatchLaterRepository()
        {
            context = new NewNetflixContext();
        }

        public WatchLater Add(WatchLater watchLater)
        {
            context.WatchLaters.Add(watchLater);
            context.SaveChanges();
            return watchLater;
        }

        public bool Delete(int id)
        {
            var watchLaters = GetById(id);

            if (watchLaters.WatchLaterId > 0)
            {
                context.WatchLaters.Remove(watchLaters);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public WatchLater GetById(int id) => context.WatchLaters.Find(id);

        public WatchLater Update(WatchLater watchLaters)
        {
            var watchLaterIdUp = GetById(watchLaters.WatchLaterId);
            context.Entry(watchLaterIdUp).CurrentValues.SetValues(watchLaters);
            context.SaveChanges();
            return watchLaterIdUp;
        }

        public IEnumerable<WatchLater> GetAll()
        {
            //select * from movies
            try
            {
                var result = context.WatchLaters
                   .Include(x => x.Mv)
                   .Include(y => y.Se)
                   .ThenInclude(y => y.UserWatches)
                   .ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"Erro : {ex.Message}");
                return Enumerable.Empty<WatchLater>();

            }
        }
    }
}

