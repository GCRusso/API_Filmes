using webapi.filmes.gabriel.Domains;

namespace webapi.filmes.gabriel.Interfaces
{
    public interface IFilmeRepository
    {
        /// <summary>
        /// Cadastrar um novo Filme(Objeto)
        /// </summary>
        /// <param name="novoFilme"> Nome do novo filme(objeto) </param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Listar todos os filmes(objetos) cadastrados
        /// </summary>
        /// <returns> Lista com os objetos </returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Atualizar objeto existente passando pelo seu ID pelo corpo de requisição
        /// </summary>
        /// <param name="Filme"> Objeto atualizado (novas informações) </param>
        void AtualizarIdCorpo(FilmeDomain Filme);

        /// <summary>
        /// Atualizar objeto existente passando o seu id pela url
        /// </summary>
        /// <param name="id"> ID do objeto que sera atualizado </param>
        /// <param name="Filme"> Objeto atualizado (novas informações) </param>
        void AtualizarUrl(int id, FilmeDomain Filme);

        /// <summary>
        /// Deletar um objeto pelo ID
        /// </summary>
        /// <param name="id"> ID do objeto que sera deletado </param>
        void Deletar(int id);

        /// <summary>
        /// Buscar objeto pelo ID
        /// </summary>
        /// <param name="id"> Objeto buscado </param>
        /// <returns></returns>
        FilmeDomain BuscarPorId(int id);
    }
}
