using Lanches.Context;
using Microsoft.EntityFrameworkCore;

namespace Lanches.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;
        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }
        public string CarrinhoCompraId { get; set; }
        public List<CompraItems> ListCompraItems { get; set; }
        public static CarrinhoCompra GetCarrinho(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDbContext>();
            string carrinhoId = session.GetString("CarrinhoCompraId") ?? Guid.NewGuid().ToString();
            session.SetString("CarrinhoCompraId", carrinhoId);
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var carrinho = _context.CarrinhoCompraItems.SingleOrDefault(l => l.Lanche.LancheId == lanche.LancheId && l.CarrinhoCompraId == CarrinhoCompraId);
            if (carrinho is not null)
            {
                carrinho.Quantidade++;
            }
            else
            {
                CompraItems compra = new CompraItems
                {
                    Lanche = lanche,
                    Quantidade = 1,
                    CarrinhoCompraId = CarrinhoCompraId
                };
                _context.CarrinhoCompraItems.Add(compra);
            }
            _context.SaveChanges();
        }
        public int RemoverDoCarrinho(Lanche lanche)
        {
            int quantidadeAtual = 0;
            var carrinho = _context.CarrinhoCompraItems.SingleOrDefault(l => l.Lanche.LancheId == lanche.LancheId && l.CarrinhoCompraId == CarrinhoCompraId);
            if (carrinho is not null)
            {
                if (carrinho.Quantidade == 1)
                {
                    _context.CarrinhoCompraItems.Remove(carrinho);
                }
                if (carrinho.Quantidade > 1)
                {
                    carrinho.Quantidade--;
                    _context.CarrinhoCompraItems.Update(carrinho);
                }
            }
            quantidadeAtual = carrinho.Quantidade;
            _context.SaveChanges();
            return quantidadeAtual;
        }
        public List<CompraItems> GetCarrinhoCompraItems()
        {
            return ListCompraItems ?? (ListCompraItems = _context.CarrinhoCompraItems
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Include(s => s.Lanche)
                .ToList());
        }
        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItems.Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);
            _context.CarrinhoCompraItems.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }
        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItems
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId).Select(b => b.Lanche.Preco * b.Quantidade).Sum();
            return total;
        }
    }
}
