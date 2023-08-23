using System.Data.SqlClient;
using webapi.filmes.gabriel.Domains;
using webapi.filmes.gabriel.Interfaces;

namespace webapi.filmes.gabriel.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = NOTE17-S15; Initial Catalog = Filmes_Gabriel; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true";
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

        /// <summary>
        /// Método para listar todos os objetos Filmes
        /// </summary>
        /// <returns> Lista de objetos (Filme) </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FilmeDomain> ListarTodos()
        {
 

            //Instanciamos a lista com uma nova lista `listaFilmes`
            List<FilmeDomain> listaFilmes= new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdFilme, IdGenero, Nome FROM Filme";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain();
                       
                            filme.IdGenero = Convert.ToInt32(rdr["IdGenero"]);
                            filme.IdFilme = Convert.ToInt32(rdr["IdFilme"]);
                            filme.Titulo = Convert.ToString(rdr["Titulo"]);

                       
                        listaFilmes.Add(filme);
                    }
                }
            }

                //Retornamos a lista
                return listaFilmes;
        }
    }
}
