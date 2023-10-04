using System.ComponentModel.DataAnnotations;

namespace Lanches.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        public int CategoriaId { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }
        [Required]
        [MaxLength(300)]
        public string Descricao { get; set;  }
        public List<Lanche> Lanches { get; set; } = new List<Lanche>();
    }
}
