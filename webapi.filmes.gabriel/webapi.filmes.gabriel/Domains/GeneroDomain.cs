using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.gabriel.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Genero
    /// </summary>
    public class GeneroDomain
    {
        [Required(ErrorMessage = "O nome do Genêro é obrigatório!")]
        public int IdGenero { get; set; }
        public string? Nome { get; set; }

        public static implicit operator GeneroDomain(FilmeDomain v)
        {
            throw new NotImplementedException();
        }
    }

}
