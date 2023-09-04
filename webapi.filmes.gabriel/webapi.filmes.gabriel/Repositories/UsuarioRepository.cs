using System.Data.SqlClient;
using System.Security;
using webapi.filmes.gabriel.Domains;
using webapi.filmes.gabriel.Interfaces;

namespace webapi.filmes.gabriel.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE17-S15; Initial Catalog = Filmes_Gabriel; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true";
        
        
        //****************************************************** LOGIN TODOS *******************************************************************
        public UsuarioDomain Login(string Email, string Senha)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT IdUsuario,Email,Permissao FROM Usuario WHERE Email = @buscaEmail AND Senha = @buscaSenha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@buscaEmail", Email);
                    cmd.Parameters.AddWithValue("@buscaSenha", Senha);
                    
                    rdr = cmd.ExecuteReader();
                }

                if (rdr.Read())
                {

                    UsuarioDomain usuarioEncontrado = new UsuarioDomain()
                    {
                        IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                        Email = rdr["Email"].ToString()!,
                        Permissao = Convert.ToBoolean(rdr["Permissao"]),
                    };


                    return usuarioEncontrado;
                }

                else
                {
                    return null;
                }

            }
        }
    }
}
