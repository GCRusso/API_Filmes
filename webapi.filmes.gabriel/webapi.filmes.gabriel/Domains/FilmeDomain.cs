using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.gabriel.Domains
{
    public class FilmeDomain
    {
        /// <summary>
        /// Classe que representa a entidade(tabela) Filme
        /// </summary>
        public int IdFilme { get; set; }
        public int IdGenero { get; set; }
        
        [Required(ErrorMessage ="O Título do filme é obrigatório!")]
        public string? Titulo { get; set; }
      
        public GeneroDomain? genero { get; set; }
    }
}
