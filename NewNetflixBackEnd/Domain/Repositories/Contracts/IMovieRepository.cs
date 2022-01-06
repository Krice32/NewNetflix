using Domain.Models;

namespace Domain.Repositories.Contracts
{
    public interface IMovieRepository
    {
        
        Movie Add(Movie movie);
        
        Movie GetById(int id);
        
        Movie Update(Movie movie);
        
        bool Delete(int id);

        IEnumerable<Movie> GetAll();

    }
}
