using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    public interface IGenreRepository
    {

        Genre Add(Genre genre);

        Genre GetById(int id);

        Genre Update(Genre genre);

        bool Delete(int id);

        IEnumerable<Genre> GetAll();
    }
}
