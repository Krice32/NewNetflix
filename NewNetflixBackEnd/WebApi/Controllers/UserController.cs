using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.InputModels;
using WebApi.Models.OutputModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// Listar todos os Usuarios
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public IActionResult ListarTodos()
        {
            UserService service = new UserService();
            return Ok(service.ListarTodosUsuarios());
        }

        /// <summary>
        /// Listar Usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return um objeto movie</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            UserService service = new UserService();
            return Ok(service.ObterUsuarioPorId(id));

        }

        /// <summary>
        /// Adicionar Usuario
        /// </summary>
        /// <param name="userInputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Adicionar(UserInputModel userInputModel)
        {
            UserService userService = new UserService();

            User user = new User();
            user.UsrId = userInputModel.UsrId;
            user.UsrName = userInputModel.UsrName;
            user.UsrEmail = userInputModel.UsrEmail;
            user.UsrPassword = userInputModel.UsrPassword;

            User userResult = userService.AdicionarAlteraUsuario(user);

            UserOutputModel userOutputModel = new UserOutputModel();
            userOutputModel.UsrId = userResult.UsrId;
            userOutputModel.UsrName = userResult.UsrName;
            userOutputModel.UsrEmail = userResult.UsrEmail;
            userOutputModel.UsrPassword = userResult.UsrPassword;

            return Created("", userOutputModel);

        }

        /// <summary>
        /// Excluir Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            UserService service = new UserService();
            return Ok(service.ExcluirUsuario(id));
        }

        /// <summary>
        /// Atualizar Usuario
        /// </summary>
        /// <param name="userInputModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(UserInputModel userInputModel, int id)
        {
            UserService service = new UserService();
            User user = new User();
            user.UsrId = userInputModel.UsrId;
            user. UsrName= userInputModel.UsrName;
            user.UsrEmail = userInputModel.UsrEmail;
            user.UsrPassword = userInputModel.UsrPassword;

            return Ok(service.AdicionarAlteraUsuario(user));

        }
    }
}
