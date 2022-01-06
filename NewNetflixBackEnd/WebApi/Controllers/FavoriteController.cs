using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.InputModels;
using WebApi.Models.OutputModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
       
        public class FavoriteController : Controller
        {
            /// <summary>
            /// Listar todos os Favoritos
            /// </summary>
            /// <returns></returns>        
            [HttpGet]
            public IActionResult ListarTodos()
            {
                FavoriteService service = new FavoriteService();
                return Ok(service.ListarTodosFavorite());
            }

            /// <summary>
            /// Listar Favorito por id
            /// </summary>
            /// <param name="id"></param>
            /// <returns>return um objeto movie</returns>
            [HttpGet("{id}")]
            public IActionResult ListarPorId(int id)
            {
                FavoriteService service = new FavoriteService();
                return Ok(service.ObterFavoritePorId(id));

            }

            /// <summary>
            /// Adicionar Favorito
            /// </summary>
            /// <param name="favoriteInputModel"></param>
            /// <returns></returns>
            [HttpPost]
            public IActionResult Adicionar(FavoriteInputModel favoriteInputModel)
            {
                FavoriteService favoriteService = new FavoriteService();

                Favorite favorite = new Favorite();
                favorite.FavoritesId = favoriteInputModel.FavoritesId;
                favorite.UsrId = favoriteInputModel.UsrId;
                favorite.MvId = favoriteInputModel.MvId;
                favorite.SeId = favoriteInputModel.SeId;

                Favorite favoriteResult = favoriteService.AdicionarAlteraFavorite(favorite);

                FavoriteOutputModel favoriteOutputModel = new FavoriteOutputModel();
                favoriteOutputModel.FavoritesId = favoriteResult.FavoritesId;
                favoriteOutputModel.UsrId = favoriteResult.UsrId;
                favoriteOutputModel.MvId = favoriteResult.MvId;
                favoriteOutputModel.SeId = favoriteResult.SeId;

                return Created("", favoriteOutputModel);

            }

            /// <summary>
            /// Excluir Favorito
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [HttpDelete("{id}")]
            public IActionResult Excluir(int id)
            {
                FavoriteService service = new FavoriteService();
                return Ok(service.ExcluirFavorite(id));
            }

            /// <summary>
            /// Atualizar Favorito
            /// </summary>
            /// <param name="favoriteInputModel"></param>
            /// <param name="id"></param>
            /// <returns></returns>
            [HttpPut("{id}")]
            public IActionResult Atualizar(FavoriteInputModel favoriteInputModel, int id)
            {
                FavoriteService service = new FavoriteService();
                Favorite favorite = new Favorite();
                favorite.FavoritesId = favoriteInputModel.FavoritesId;
                favorite.UsrId = favoriteInputModel.UsrId;
                favorite.MvId = favoriteInputModel.MvId;
                favorite.SeId = favoriteInputModel.SeId;

                return Ok(service.AdicionarAlteraFavorite(favorite));

            }
        }
    }

