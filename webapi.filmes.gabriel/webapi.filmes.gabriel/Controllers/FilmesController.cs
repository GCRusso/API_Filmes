using Microsoft.AspNetCore.Mvc;
using webapi.filmes.gabriel.Domains;
using webapi.filmes.gabriel.Interfaces;
using webapi.filmes.gabriel.Repositories;

namespace webapi.filmes.gabriel.Controllers
{    
    //Define que a rota de uma requisição será no seguinte formato
    //Dominio/api/nomecontroller
    //Ex: http://localhost:5000/api/filme
    [Route("api/[controller]")]


    //Define que é um controlador API
    [ApiController]

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("Application/json")]
    public class FilmesController : ControllerBase
    {

        /// <summary>
        /// Objeto _filmeRepository que irá receber todos os métodos definidos na interface IFilmeRepository
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }

        //Metodo Construtor, possui o mesmo nome que a classe
        /// <summary>
        /// Instancia o objeto _filmeRepository para que haja referencia aos metodos no repositorio
        /// </summary>
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }




        //********************************************************************** GET  ****************************************************************************
        /// <summary>
        /// Endpoint que aciona o metodo ListarTodos no repositorio
        /// </summary>
        /// <returns> Retonar a resposta para o usuario (front-end) </returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();
                
                return Ok(listaFilmes);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        //**************************************************************************** GET BUSCAR POR ID ******************************************************
        /// <summary>
        /// Endpoint que aciona o método BuscarPorId 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retorna o objeto pedido na requisição </returns>
        
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);
                if (filmeBuscado == null)
                {
                    return NotFound("Nenhum Gênero foi encontrado");
                }

                return Ok(filmeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //**********************************************************************  POST  ****************************************************************************
        /// <summary>
        /// Endpoint que aciona o metodo de cadastro de Filme
        /// </summary>
        /// <param name="novoFilme"></param>
        /// <returns> Objeto recebido na requisição </returns>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {

            try
            {
                //_generoRepository utiliza os metodos, foi declarado no inicio do codigo
                //Fazendo a chamada do metodo passando como parametro o objeto
                _filmeRepository.Cadastrar(novoFilme);

                //Retorna um status code 201
                return StatusCode(201);
            }

            catch (Exception erro)
            {
                //Retorna um BadRequest, mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        //**********************************************************************  DELETE  ****************************************************************************
       /// <summary>
       /// Endpoint que aciona o método Delete
       /// </summary>
       /// <param name="id"></param>
       /// <returns> Deleta o Filme cadastrado através do seu ID </returns>
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }


        //**************************************************************************** PUT UPDATE PELO URL ******************************************************
        /// <summary>
        /// Endpoint que aciona o método AtualizarUrl
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Filme"></param>
        /// <returns> Atualiza o Filme cadastrado pelo url </returns>
        [HttpPut("{id}")]

        public IActionResult Put(int id, FilmeDomain Filme)
        {
            try
            {
                _filmeRepository.AtualizarUrl(id, Filme);
                return StatusCode(204);
            }

            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        // //**************************************************************************** PUT UPDATE PELO CORPO ******************************************************

        /// <summary>
        /// Endpoint que aciona o método AtualizarIdCorpo
        /// </summary>
        /// <param name="Filme"></param>
        /// <returns></returns>
        [HttpPut]

        public IActionResult Put(FilmeDomain Filme)
        {
            try
            {
                _filmeRepository.AtualizarIdCorpo(Filme);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }

}
