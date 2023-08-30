using System.Data.SqlClient;
using webapi.filmes.gabriel.Domains;
using webapi.filmes.gabriel.Interfaces;

namespace webapi.filmes.gabriel.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE17-S15; Initial Catalog = Filmes_Gabriel; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true";
        
        
        //************************************************************************ LOGIN TODOS *******************************************************************
        public UsuarioDomain Login(string Email, string Senha)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT Email,Senha,Permissao FROM Usuario WHERE Email = @buscaEmail AND Senha = @buscaSenha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    rdr= cmd.ExecuteReader();


                }
            }
        }
    }
}
