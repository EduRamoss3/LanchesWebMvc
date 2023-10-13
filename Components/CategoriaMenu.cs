using Lanches.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lanches.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _CategoriaRepository;
        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _CategoriaRepository = categoriaRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categorias = _CategoriaRepository.Categorias.OrderBy(l => l.CategoriaNome);
            return View(categorias);
        }
    }
}
