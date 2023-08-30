using Microsoft.AspNetCore.Mvc;
using webapi.filmes.gabriel.Repositories;

namespace webapi.filmes.gabriel.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("Application/json")]
    public class UsuarioController : ControllerBase
    {
        //Objeto que receberá todos os métodos definidos na interface
        private UsuarioRepository _usuarioRepository { get; set; }

        //Método Construtor
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        //*********************************************************************** GET ******************************************************
       /// <summary>
       /// Endpoint que aciona o método
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
