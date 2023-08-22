using webapi.filmes.gabriel.Domains;
using webapi.filmes.gabriel.Interfaces;

namespace webapi.filmes.gabriel.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = NOTE17-S15; Initial Catalog = Filmes_Gabriel; User Id = sa; Pwd = Senai@134;";
        public void AtualizarIdCorpo(FilmeDomain Filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarUrl(int id, FilmeDomain Filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
