using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FavoriteService
    {
        FavoriteRepository favoriteRepository;
        public FavoriteService()
        {
            favoriteRepository = new FavoriteRepository();
        }

        public Favorite AdicionarAlteraFavorite(Favorite favorite)
        {
            try
            {
                #region regra de negócio

                bool addFlag = favorite.FavoritesId == 0 ? true : false;

                #endregion

                #region Adicionar ou Alterar Genero

                return addFlag ? favoriteRepository.Add(favorite) : favoriteRepository.Update(favorite);

                #endregion

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }
        }

        public Favorite ObterFavoritePorId(int id)
        {
            try
            {
                return favoriteRepository.GetById(id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }


        }

        public bool ExcluirFavorite(int id)
        {
            try
            {
                return favoriteRepository.Delete(id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return false;
            }

        }

        public IEnumerable<Favorite> ListarTodosFavorite() => favoriteRepository.GetAll();

    }
}

