using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.gabriel.Domains
{
    public class UsuarioDomain
    {

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória!")]
        public string Senha { get; set; }

        public bool Permissao { get; set; }


    }
}
