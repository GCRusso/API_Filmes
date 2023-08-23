﻿using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;
using webapi.filmes.gabriel.Domains;
using webapi.filmes.gabriel.Interfaces;

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


        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

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
                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
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
