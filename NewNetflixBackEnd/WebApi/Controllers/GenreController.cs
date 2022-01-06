using Application.Services;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Models.InputModels;
using WebApi.Models.OutputModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : Controller
    {

 
        /// <summary>
        /// Listar todos os gêneros
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public IActionResult ListarTodos()
        {
            GenreService service = new GenreService();
            return Ok(service.ListarTodosGenres());
        }

        /// <summary>
        /// Listar gêneros por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return um objeto movie</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            GenreService service = new GenreService();
            return Ok(service.ObterGenrePorId(id));

        }

        /// <summary>
        /// Adicionar gênero
        /// </summary>
        /// <param name="genreInputModel"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Adicionar(GenreInputModel genreInputModel)
        {
            GenreService genreService = new GenreService();

            Genre genre = new Genre();
            genre.GrId = genreInputModel.GrId;
            genre.Genre1 = genreInputModel.Genre1;
          
            Genre genreResult = genreService.AdicionarAlteraGenre(genre);

            GenreOutputModel genreOutputModel = new GenreOutputModel();
            genreOutputModel.GrId = genreResult.GrId;
            genreOutputModel.Genre1 = genreResult.Genre1;
      

            return Created("", genreOutputModel);

        }

        /// <summary>
        /// Excluir gênero
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            GenreService service = new GenreService();
            return Ok(service.ExcluirGenre(id));
        }

        /// <summary>
        /// Atualizar gênero
        /// </summary>
        /// <param name="genreInputModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(GenreInputModel genreInputModel, int id)
        {
            GenreService service = new GenreService();
            Genre genre = new Genre();
            genre.GrId = genreInputModel.GrId;
            genre.Genre1 = genreInputModel.Genre1;
           

            return Ok(service.AdicionarAlteraGenre(genre));

        }

    }
}
