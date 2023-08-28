using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;
using webapi.filmes.gabriel.Domains;
using webapi.filmes.gabriel.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.gabriel.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parâmetros
        /// Data Source: Nome do Servidor
        /// Initial Catalog: Nome do banco de dados
        /// Atenticação:
        ///     - Windows: Integrated Security = true;
        ///     - SqlServer: User Id = inserir o usuario; pwd = inserir a senha;
        /// </summary>
        private string StringConexao = "Data Source = NOTE17-S15; Initial Catalog = Filmes_Gabriel; User Id = sa; Pwd = Senai@134;";




        //*************************************************************** ATUALIZAR ID CORPO *************************************************************************************
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }




        //***************************************************************ATUALIZAR ID URL*************************************************************************************
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }




        //***************************************************************BUSCAR POR ID*************************************************************************************
        /// <summary>
        /// Buscar um genero atraves do seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Objeto encontrado ou null caso nao seja encontrado </returns>
        public GeneroDomain BuscarPorId(int id)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdBuscado";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdBuscado", id);

                    rdr = cmd.ExecuteReader();

                    //Verifica se o resultado retornou algum registro
                    if (rdr.Read())
                    {
                        //Se sim, instancia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero o valor da coluna "IdGenero" da tabela do banco de dados
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            //Atribui a propriedade Nome o valor da coluna "Nome" da tabela do banco de dados
                            Nome = rdr["Nome"].ToString()
                        };

                        //Retorna o generoBuscado com os dados obtidos
                        return generoBuscado;
                    }

                    else
                    {
                        //Retorno null caso nao seja encontrado
                        return null;
                    }

                }
            }
        }
                //***************************************************************CADASTRAR*************************************************************************************
                /// <summary>
                /// Cadastrar um novo Genero
                /// </summary>
                /// <param name="novoGenero"> Objeto com as informações que serão cadastradas </param>
                /// <exception cref="NotImplementedException"></exception>
                public void Cadastrar(GeneroDomain novoGenero)
                {
                    //Declara a conexão passando a string de conexão como parametro
                    using (SqlConnection con = new SqlConnection(StringConexao))
                    {
                        /*Declara o que sera executado, utilize desta forma para CONCATENAR, 
                         * porem assim da o erro conhecido como Joana D'arc, todos os caracteres especiais que for inserido da erro ao cadastrar
                      string queryInsert = "INSERT INTO Genero(Nome) VALUES (' " + novoGenero.Nome + " ')";*/

                        //Assim evitamos o erro Joana D`arc
                        string queryInsert = "INSERT INTO Genero(Nome) VALUES (@Nome)";


                        //Declara o SqlCommand passando a query que sera executada e a conexão
                        using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                        {
                            //Passa o valor para o parâmetro @Nome
                            cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                            //Abre a conexão com o banco de dados, pode ser utilizado dnetro do primeiro ou do segundo USING
                            con.Open();

                            //comando para executar a queryInsert
                            cmd.ExecuteNonQuery();
                        }
                    }
                }




                //***************************************************************DELETAR*************************************************************************************
                /// <summary>
                /// Deletar um genero
                /// </summary>
                /// <param name="Id"></param>
                public void Deletar(int Id)
                {
                    using (SqlConnection con = new SqlConnection(StringConexao))
                    {
                        string queryDelete = "DELETE FROM Genero WHERE IdGenero = @IdDelete";

                        using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                        {
                            cmd.Parameters.AddWithValue("@IdDelete", Id);

                            con.Open();

                            cmd.ExecuteNonQuery();
                        }
                    }
                }




                //***************************************************************LISTAR TODOS*************************************************************************************
                /// <summary>
                /// Objeto para listar todos os objetos Generos
                /// </summary>
                /// <returns> Lista de objetos (Genero) </returns>
                /// <exception cref="NotImplementedException"></exception>
                public List<GeneroDomain> ListarTodos()
                {
                    //instanciamos a lista como um nova lista `listaGeneros`
                    List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

                    //Utilizando o Using não precisamos finalizar o using, ele automáticamente já finaliza.
                    //Declara a Sql Connection passando a string de conexão como parâmetro
                    using (SqlConnection con = new SqlConnection(StringConexao))
                    {
                        //Declara a instrução a ser executada, pegamos os dados da tabela e inserimos no (SqlDataReader rdr)
                        string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                        //Abre a conexão com o banco de dados
                        con.Open();

                        //Declara o SqlDataReader para percorrer a tabela do banco de dados
                        //Aqui com os dados que selecionamos ele fara a leitura(Reader)
                        SqlDataReader rdr;

                        //Declara o SqlCommand passando a query que sera executada e a conexao com o banco de dados
                        //Pegamos o que sera apresentado na string que guardamos e  executamos com o command 
                        using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                        {
                            //Executa a query e armazena os dados do rdr
                            //Pegamos os dados que o rdr fez a leitura e executa com o cmd
                            rdr = cmd.ExecuteReader();

                            //Enquanto tivermos um novo objeto em nossa lista para ser lido 
                            while (rdr.Read())
                            {
                                GeneroDomain genero = new GeneroDomain()
                                {
                                    //onde estao as informacoes de cada item Id e nome? estao no rdr
                                    //convertemos o rdr para o formato INT

                                    //IdGenero = Convert.ToInt32(rdr[0]), deste modo voce puxa pelo um Id

                                    //Pode se fazer deste modo puxando direto o IdGenero
                                    IdGenero = Convert.ToInt32(rdr["IdGenero"]),


                                    //Atribui cada objeto dentro da lista
                                    Nome = rdr["Nome"].ToString()

                                };
                                //Adiciona cada objeto dentro da lista
                                listaGeneros.Add(genero);
                            }
                        }
                    }

                    //Retornamos a lista
                    return listaGeneros;
                }
            
        
    }
}
