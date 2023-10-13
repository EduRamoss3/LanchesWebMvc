using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lanches.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o sobrenome")]
        [StringLength(50)]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Informe o endereço")]
        [StringLength(100)]
        [Display(Name ="Endereço")]
        public string Endereco1 { get; set; }
        public string Endereco2 { get; set; }
        [Required(ErrorMessage = "Informe o seu CEP")]
        [StringLength(10, MinimumLength = 8)]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Informe o telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Informe o email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"?: [a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%)]",ErrorMessage ="O email não possui um formato correto.")]
        public string Email { get; set; }
        [Display(Name ="Data do pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]    
        public DateTime PedidoEnviado { get; set; }
        [Display(Name = "Data da entrega")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime PedidoEntregueEm { get; set; }
        public List<PedidoDetalhe> PedidoItens { get; set; }


    }
}
