using Lanches.Models;

namespace Lanches.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }  
        public string CategoriaAtual { get; set; }
    }
}
