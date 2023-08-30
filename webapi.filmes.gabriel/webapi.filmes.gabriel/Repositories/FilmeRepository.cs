using System.Data.SqlClient;
using webapi.filmes.gabriel.Domains;
using webapi.filmes.gabriel.Interfaces;

namespace webapi.filmes.gabriel.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = NOTE17-S15; Initial Catalog = Filmes_Gabriel; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true";

    

        //************************************************************************ ATUALIZAR ID PELO CORPO *******************************************************************
        /// <summary>
        /// Método para atualizar Filme pelo ID CORPO
        /// </summary>
        /// <param name="Filme"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AtualizarIdCorpo(FilmeDomain Filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateByBody = "UPDATE Filme SET Titulo = @novoTitulo, IdGenero = @novoIdGenero WHERE IdFilme = @buscaIdFilme";

                using (SqlCommand cmd = new SqlCommand(queryUpdateByBody, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@novoTitulo", Filme.Titulo);
                    cmd.Parameters.AddWithValue("@buscaIdFilme",Filme.IdFilme);
                    cmd.Parameters.AddWithValue("@novoIdGenero", Filme.IdGenero);

                    cmd.ExecuteNonQuery();
                }

            }
        }



        //************************************************************************ ATUALIZAR ID PELO URL *******************************************************************
        /// <summary>
        /// Método para atualizar Filme pelo ID URL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Filme"></param>
        public void AtualizarUrl(int id, FilmeDomain Filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateByUrl = "UPDATE Filme SET Titulo = @novoFilme, IdGenero = @novoIdGenero WHERE IdFilme = @IdBuscado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateByUrl, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@IdBuscado", id);
                    cmd.Parameters.AddWithValue("@novoFilme", Filme.Titulo);
                    cmd.Parameters.AddWithValue("@novoIdGenero",Filme.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }




        //************************************************************************ BUSCAR POR ID *******************************************************************
        /// <summary>
        /// Metodo para buscar filme pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Titulo do Filme buscado </returns>
        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT IdFilme, Titulo FROM Filme WHERE IdFilme = @IdBuscado";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdBuscado", id);
                    
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filmeBuscado = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            Titulo = rdr["Titulo"].ToString()

                        };

                        return filmeBuscado;
                    }

                    else
                    {
                        return null;
                    }
                }
            }
        }




        //************************************************************************ CADASTRAR *******************************************************************
        /// <summary>
        /// Método para cadastrar Filmes
        /// </summary>
        /// <param name="novoFilme"></param>
        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Filme(Titulo, IdGenero) VALUES (@Titulo, @IdGenero)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }





        //************************************************************************ DELETAR PELO ID*******************************************************************

        /// <summary>
        /// Método para deletar Filmes
        /// </summary>
        /// <param name="id"></param>
        void IFilmeRepository.Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Filme WHERE IdFilme = @IdDelete";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdDelete", id);

                    con.Open(); 

                    cmd.ExecuteNonQuery();  
                }
            }
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
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),
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


