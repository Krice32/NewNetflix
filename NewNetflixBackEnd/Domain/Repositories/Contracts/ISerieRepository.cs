using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    public interface ISerieRepository
    {           
        Series Add(Series serie);

        Series GetById(int id);

        Series Update(Series serie);
        
        bool Delete(int id);
        IEnumerable<Series> GetAll();
    }
}
