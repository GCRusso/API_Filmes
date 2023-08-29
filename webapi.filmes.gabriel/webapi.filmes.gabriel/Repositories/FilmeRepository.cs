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




        //************************************************************************ ATUALIZAR ID PELO URL *******************************************************************
        public void AtualizarUrl(int id, FilmeDomain Filme)
        {
            throw new NotImplementedException();
        }




        //************************************************************************ BUSCAR POR ID *******************************************************************
        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }




        //************************************************************************ CADASTRAR *******************************************************************
        public void Cadastrar(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }





        //************************************************************************ DELETAR PELO ID*******************************************************************


        void IFilmeRepository.Deletar(int id)
        {
            throw new NotImplementedException();
        }


        //************************************************************************ LISTAR TODOS *******************************************************************
        /// <summary>
        /// Método para listar todos os objetos Filmes
        /// </summary>
        /// <returns> Lista de objetos (Filme) </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FilmeDomain> ListarTodos()
        {

            //Instanciamos a lista com uma nova lista `listaFilmes`
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdFilme, Filme.IdGenero, Titulo,Genero.Nome FROM Filme INNER JOIN Genero ON Genero.IdGenero = Filme.IdGenero";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Titulo = Convert.ToString(rdr["Titulo"]),

                            genero = new GeneroDomain()
                            {

                                Nome = Convert.ToString(rdr["Nome"])

                            }
                        };
                        listaFilmes.Add(filme);

                    }
                }
            }

            //Retornamos a lista
            return listaFilmes;
        }
    }
}


