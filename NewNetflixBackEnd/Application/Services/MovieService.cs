using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class MovieService
    {
        MovieRepository movieRepository;
        public MovieService()
        {
            movieRepository = new MovieRepository();
        }

        public Movie AdicionarAlteraMovie(Movie movie)
        {
            try
            {
                #region regra de negócio

                bool addFlag = movie.MvId == 0 ? true : false;

                #endregion

                #region Adicionar ou Alterar Movie

                return addFlag ? movieRepository.Add(movie) : movieRepository.Update(movie);

                #endregion

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }
        }

        public Movie ObterMoviePorId(int id)
        {
            try
            {
                return movieRepository.GetById(id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }


        }

        public bool ExcluirMovie (int id)
        {
            try
            {
                return movieRepository.Delete(id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return false;
            }
            
        }

        public IEnumerable<Movie> ListarTodosMovies() => movieRepository.GetAll();
        

    }
}
