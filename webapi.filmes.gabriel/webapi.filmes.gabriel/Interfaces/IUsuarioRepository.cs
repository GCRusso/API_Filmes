using webapi.filmes.gabriel.Domains;

namespace webapi.filmes.gabriel.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Listar todos os usuários Cadastrados
        /// </summary>
        /// <returns> Lista com Usuários(Objetos) </returns>
        public UsuarioDomain Login(string Email, string Senha);
    }
}
