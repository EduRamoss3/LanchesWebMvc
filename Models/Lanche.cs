using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lanches.Models
{
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório!")]
        [MaxLength(100,ErrorMessage ="O nome deve possuir no máximo 100 caracteres.")]
        public string Nome { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Descrição curta")]
        public string DescricaoCurta { get; set; }
        [Required]
        [MaxLength(300)]
        [Display(Name ="Descrição detalhada")]
        public string DescricaoDetalhada { get; set; }
        [Required(ErrorMessage ="O preço não pode ser nulo.")]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        [MaxLength(500)]
        [Display(Name = "Imagem")]
        public string ImagemUrl { get; set; }
        [MaxLength(500)]
        [Display(Name = "Thumbnail")]
        public string ImagemThumbnailUrl { get; set; }
        [Required]
        [Display(Name = "Lanche preferido")]
        public bool IsLanchePreferido { get; set; }
        [Required(ErrorMessage ="O lanche deve ou não estar em um estoque.")]
        [Display(Name = "Em estoque")]
        public bool EmEstoque { get; set; }
        [Required(ErrorMessage ="Um lanche deve conter pelo menos uma categoria!")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
