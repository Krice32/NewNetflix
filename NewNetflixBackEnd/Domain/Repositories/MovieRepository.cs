using Domain.Models;
using Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        NewNetflixContext context;

        public MovieRepository()
        {
             context = new NewNetflixContext();
        }

        public Movie Add(Movie movie)
        {            
            context.Movies.Add(movie);
            context.SaveChanges();
            return movie;
        }

        public bool Delete(int id)
        {
            var movie = GetById(id);

            if (movie.MvId > 0)
            {
                context.Movies.Remove(movie);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public Movie GetById(int id) => context.Movies.Find(id);        

        public Movie Update(Movie movie)
        {
            var movieUp = GetById(movie.MvId);
            context.Entry(movieUp).CurrentValues.SetValues(movie);
            context.SaveChanges();            
            return movieUp;
        }

        public IEnumerable<Movie> GetAll() => context.Movies.ToList();
            //select * from movies
        

      
    }
}
