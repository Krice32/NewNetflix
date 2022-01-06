using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    public interface IWatchLater
    {
        WatchLater Add(WatchLater watchLater);

        WatchLater GetById(int id);

        WatchLater Update(WatchLater watchLater);

        bool Delete(int id);

        IEnumerable<WatchLater> GetAll();

    }
}
