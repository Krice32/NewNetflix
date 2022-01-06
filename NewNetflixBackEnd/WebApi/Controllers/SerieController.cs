using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.InputModels;
using WebApi.Models.OutputModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SerieController : Controller
    {
        /// <summary>
        /// Listar todas as série
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            SerieService service = new SerieService();
            return Ok(service.ListarTodasSeries());
        }

        /// <summary>
        /// Listar série por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return um objeto movie</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            SerieService service = new SerieService();
            return Ok(service.ObterSeriePorId(id));

        }

        /// <summary>
        /// Adicionar Série
        /// </summary>
        /// <param name="serieInputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Adicionar(SerieInputModel serieInputModel)
        {

            SerieService serieService = new SerieService();

            Series serie = new Series();
            serie.SeId = serieInputModel.SeId;
            serie.SeTitle = serieInputModel.SeTitle;
            serie.SeDate = serieInputModel.SeDate;
            serie.GrId = serieInputModel.GrId;

            Series movieResult = serieService.AdicionarAlteraSerie(serie);

            SerieOutputModel serieOutputModel = new SerieOutputModel();
            serieOutputModel.SeId = movieResult.SeId;
            serieOutputModel.SeDate = movieResult.SeDate;
            serieOutputModel.SeTitle = movieResult.SeTitle;
            serieOutputModel.GrId = movieResult.GrId;

            return Created("", serieOutputModel);

        }

        /// <summary>
        /// Excluir Série
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            SerieService service = new SerieService();
            return Ok(service.ExcluirSerie(id));
        }

        /// <summary>
        /// Atualizar Série
        /// </summary>
        /// <param name="serieInputModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(SerieInputModel serieInputModel, int id)
        {

            SerieService service = new SerieService();
            Series serie = new Series();
            serie.SeId = serieInputModel.SeId;
            serie.SeTitle = serieInputModel.SeTitle;
            serie.SeDate = serieInputModel.SeDate;
            serie.GrId = serieInputModel.GrId;

            return Ok(service.AdicionarAlteraSerie(serie));

        }
    }
}
