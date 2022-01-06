
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenreService
    {
        GenreRepository genreRepository;
        public GenreService()
        {
            genreRepository = new GenreRepository();
        }

        public Genre AdicionarAlteraGenre(Genre genre)
        {
            try
            {
                #region regra de negócio

                bool addFlag = genre.GrId == 0 ? true : false;

                #endregion

                #region Adicionar ou Alterar Genero

                return addFlag ? genreRepository.Add(genre) : genreRepository.Update(genre);

                #endregion

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }
        }

        public Genre ObterGenrePorId(int id)
        {
            try
            {
                return genreRepository.GetById(id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }


        }

        public bool ExcluirGenre(int id)
        {
            try
            {
                return genreRepository.Delete(id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return false;
            }

        }

        public IEnumerable<Genre> ListarTodosGenres() => genreRepository.GetAll();

    }
}
