using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.InputModels;
using WebApi.Models.OutputModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WatchLaterController : Controller
    {
        /// <summary>
        /// Listar todos para assistir mais tarde
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public IActionResult ListarTodos()
        {
            WatchLaterService service = new WatchLaterService();
            return Ok(service.ListarTodosAssistirMaisTarde());
        }

        /// <summary>
        /// Listar assistir mais tarde por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return um objeto movie</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            WatchLaterService service = new WatchLaterService();
            return Ok(service.ObterAssistirMaisTardePorId(id));

        }

        /// <summary>
        /// Adicionar na lista de assistir mais tarde
        /// </summary>
        /// <param name="watchLaterInputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Adicionar(WatchLaterInputModel watchLaterInputModel)
        {
            WatchLaterService watchLaterService = new WatchLaterService();

            WatchLater watchLater = new WatchLater();
            watchLater.WatchLaterId = watchLaterInputModel.WatchLaterId;
            watchLater.UsrId = watchLaterInputModel.UsrId;
            watchLater.MvId = watchLaterInputModel.MvId;
            watchLater.SeId = watchLaterInputModel.SeId;

            WatchLater watchLaterResult = watchLaterService.AdicionarAlteraAssistirMaisTarde(watchLater);

            WatchLaterOutputModel watchLaterOutputModel = new WatchLaterOutputModel();
            watchLaterOutputModel.WatchLaterId = watchLaterResult.WatchLaterId;
            watchLaterOutputModel.UsrId = watchLaterResult.UsrId;
            watchLaterOutputModel.MvId = watchLaterResult.MvId;
            watchLaterOutputModel.SeId = watchLaterResult.SeId;

            return Created("", watchLaterOutputModel);

        }

        /// <summary>
        /// Excluir da lista de assistir mais tarde
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            WatchLaterService service = new WatchLaterService();
            return Ok(service.ExcluirAssistirMaisTarde(id));
        }

        /// <summary>
        /// Atualizar na lista de assistir mais tarde
        /// </summary>
        /// <param name="watchLaterInputModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(WatchLaterInputModel watchLaterInputModel, int id)
        {
            WatchLaterService service = new WatchLaterService();
            WatchLater watchLater = new WatchLater();
            watchLater.WatchLaterId = watchLaterInputModel.WatchLaterId;
            watchLater.UsrId = watchLaterInputModel.UsrId;
            watchLater.MvId = watchLaterInputModel.MvId;
            watchLater.SeId = watchLaterInputModel.SeId;

            return Ok(service.AdicionarAlteraAssistirMaisTarde(watchLater));

        }
    }
}
