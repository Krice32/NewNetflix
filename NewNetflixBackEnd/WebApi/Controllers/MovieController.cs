using Application.Services;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        /// <summary>
        /// Listar todos os Movies
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public IActionResult ListarTodos()
        {            
            MovieService service = new MovieService();
            return Ok(service.ListarTodosMovies());
        }

        /// <summary>
        /// Listar movie por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return um objeto movie</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            MovieService service = new MovieService();
            return Ok(service.ObterMoviePorId(id));
            
        }

        /// <summary>
        /// Adicionar Movie
        /// </summary>
        /// <param name="movieInputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Adicionar(MovieInputModel movieInputModel)
        {          
            MovieService movieService = new MovieService();

            Movie movie = new Movie();
            movie.MvId = movieInputModel.MvId;
            movie.MvDate = movieInputModel.MvDate;
            movie.MvTitle = movieInputModel.MvTitle;
            movie.GrId = movieInputModel.GrId;

            Movie movieResult = movieService.AdicionarAlteraMovie(movie);

            MovieOutputModel movieOutputModel = new MovieOutputModel();
            movieOutputModel.MvId = movieResult.MvId;
            movieOutputModel.MvDate = movieResult.MvDate;
            movieOutputModel.MvTitle = movieResult.MvTitle;
            movieOutputModel.GrId = movieResult.GrId;

            return Created("",movieOutputModel);
            
        }

        /// <summary>
        /// Excluir Movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            MovieService service = new MovieService();
            return Ok(service.ExcluirMovie(id));            
        }

        /// <summary>
        /// Atualizar Movie
        /// </summary>
        /// <param name="movieInputModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(MovieInputModel movieInputModel, int id)
        {
            MovieService service = new MovieService();
            Movie movie = new Movie();
            movie.MvId = movieInputModel.MvId;
            movie.MvTitle = movieInputModel.MvTitle;
            movie.MvDate = movieInputModel.MvDate;
            movie.GrId = movieInputModel.GrId;

            return Ok(service.AdicionarAlteraMovie(movie));             
          
        }

    }
}
