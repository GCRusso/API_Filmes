using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using webapi.filmes.gabriel.Domains;
using webapi.filmes.gabriel.Interfaces;
using webapi.filmes.gabriel.Repositories;

namespace webapi.filmes.gabriel.Controllers
{
    //Define que a rota de uma requisição será no seguinte formato
    //Dominio/api/nomecontroller
    //Ex: http://localhost:5000/api/genero
    [Route("api/[controller]")]

    //Define que é um controlador API
    [ApiController]

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("Application/json")]

    //Método controlador que herda da controller base
    //Onde será criado os Endpoints(Rotas)
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        //Metodo Construtor, possui o mesmo nome que a classe
        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referencia aos metodos no repositorio
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }
        
        //********************************************************************** GET ****************************************************************************
        /// <summary>
        /// Endpoint que aciona o metodo ListarTodos no repositorio
        /// </summary>
        /// <returns> retorna a respota para o usuario(front-end) </returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //se tiver acesso e estiver tudo certo ele entrega a lista de generos
                //cria uma lista que recebe os dados da requisicao
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                //retorna a lista com o formato JSON com o status code OK(200) 
                return Ok(listaGeneros);
            }
            catch (Exception erro)
            {
                //se caso nao tiver acesso ou estiver algo errado ele entrega um erro
                //Retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }

        }
        //********************************************************************** POST ****************************************************************************
        /// <summary>
        /// Endpoint que aciona o metodo de cadastro de genero
        /// </summary>
        /// <param name="novoGenero"></param>
        /// <returns> Objeto recebido na requisição </returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {

            try
            {
                //_generoRepository utiliza os metodos, foi declarado no inicio do codigo
                //Fazendo a chamada do metodo passando como parametro o objeto
                _generoRepository.Cadastrar(novoGenero);

                //Retorna um status code 201
                return StatusCode(201);
            }

            catch (Exception erro)
            {
                //Retorna um BadRequest, mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        //********************************************************************** DELETE ****************************************************************************
        /// <summary>
        /// Endpoint que aciona o método Deletar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> Deleta o genero pelo ID </returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _generoRepository.Deletar(Id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }
    }

}
