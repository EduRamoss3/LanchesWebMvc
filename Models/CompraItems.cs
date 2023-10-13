using System.ComponentModel.DataAnnotations;

namespace Lanches.Models
{
    public class CompraItems
    {
        public int CompraItemsId { get; set; }
        public Lanche Lanche { get; set; }
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}
