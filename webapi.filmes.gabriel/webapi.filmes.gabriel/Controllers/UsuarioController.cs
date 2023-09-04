using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
           
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuarioLogin.Email, usuarioLogin.Senha);
               
                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou Senha inválidos, Por favor tente novamente!");
                }

                //CRIANDO O JWT
                //Caso encontre o usuário, prossegue para a criação do token

                //1º - Definir as informações(Claims) que serão fornecidos no token (PAYLOAD)

                var claims = new[]
                {
                    //Usado JTI para ID
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role,usuarioBuscado.Permissao.ToString()),

                    //Existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada", "Valor da Claim Personalizada")
                };

                //2º - Definir a chave de acesso ao token, tem que ser uma chave de grande porte como esta que estamos utilizando, bem detalhada.
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chaves-autenticacao-webapi-dev"));

                //3º - Definir as credenciais do token (HEADER), pede a chave que declaramos a cima e depois o tipo de criptografia
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º - Gerar Token
                var token = new JwtSecurityToken
                (
                    //Emissor do Token
                    issuer: "webapi.filmes.gabriel",

                    //Destinatario do Token
                    audience: "webapi.filmes.gabriel",

                    //Dados definidos nas claims(Informações)
                    claims: claims,

                    //Tempo de expiração do token
                    expires: DateTime.Now.AddMinutes(5),

                    //Credenciais do token
                    signingCredentials: creds
                );

                //5º - Retornar o token criado
                return Ok(new
                { 
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }

            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

            
        }
    }
}
