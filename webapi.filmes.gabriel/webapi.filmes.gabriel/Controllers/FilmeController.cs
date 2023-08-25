using Microsoft.AspNetCore.Mvc;
using webapi.filmes.gabriel.Interfaces;
using webapi.filmes.gabriel.Repositories;

namespace webapi.filmes.gabriel.Controllers
{
    [Route("api/[controller]")]

    [ApiController ]
    [Produces("Application/json")]
    public class FilmeController : Controller
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
