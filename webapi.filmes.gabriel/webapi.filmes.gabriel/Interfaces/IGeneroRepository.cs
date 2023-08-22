using webapi.filmes.gabriel.Domains;

namespace webapi.filmes.gabriel.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// Definir os métodos que serão implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //TipoRetorno NomeMetodo(TipoParametro NomeParametro)
        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero"> Nome do novo genero (OBJETO) </param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns> Lista com os objetos </returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Atualizar objeto existente passando pelo seu ID pelo corpo de requisição
        /// </summary>
        /// <param name="genero"> Objeto atualizado (novas informações) </param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar objeto existente passando o seu id pela url
        /// </summary>
        /// <param name="id"> ID do objeto que sera atualizado</param>
        /// <param name="genero"> Objeto atualizado (novas informações) </param>
        void AtualizarIdUrl(int id, GeneroDomain genero);


        /// <summary>
        /// Deletar o objeto
        /// </summary>
        /// <param name="id"> ID do objeto que será deletado </param>
        void Deletar(int id);
        
        /// <summary>
        /// Busca um objeto através do seu ID 
        /// </summary>
        /// <param name="id"> ID do objeto a ser buscado </param>
        /// <returns> Objeto Buscado </returns>
        GeneroDomain BuscarPorId(int id);
    }
}
