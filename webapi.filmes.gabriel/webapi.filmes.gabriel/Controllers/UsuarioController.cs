using Microsoft.AspNetCore.Mvc;
using webapi.filmes.gabriel.Domains;
using webapi.filmes.gabriel.Interfaces;
using webapi.filmes.gabriel.Repositories;

namespace webapi.filmes.gabriel.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("Application/json")]
    public class UsuarioController : ControllerBase
    {
        //Objeto que receberá todos os métodos definidos na interface
        private IUsuarioRepository _usuarioRepository { get; set; }

        //Método Construtor
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

      //*********************************************************************** GET ******************************************************
      /// <summary>
      /// Endpoint que aciona o método Login
      /// </summary>
      /// <returns> Retorna os dados do usuário caso encontrado </returns>
      
        [HttpPost]
        //Utilizar um LOGIN como POST por boas práticas, sempre inserir os dados pelo CORPO para proteção de dados do usuário.
        public IActionResult Post(UsuarioDomain usuarioLogin)
        {
           UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuarioLogin.Email, usuarioLogin.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou Senha inválidos, Por favor tente novamente!");
            }
            else
            {
                return Ok(usuarioBuscado);
            }
            
            
        }
    }
}
