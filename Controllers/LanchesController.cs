using Lanches.Models;
using Lanches.Repositories.Interfaces;
using Lanches.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Lanches.Controllers
{
    public class LanchesController : Controller
    {
        private readonly ILancheRepository _repository;
        public LanchesController(ILancheRepository repository) {
            _repository = repository;
        }
        public IActionResult Lanche(int id) // Mais detalhes
        {
            var lanche = _repository.GetLancheById(id);
            return View(lanche);
        }
        public IActionResult Index(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _repository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else 
            {
                char firstLetter = categoria.ToUpper()[0];
                string newCategoria = categoria.Replace(categoria[0], firstLetter); 
             
                var fCategory = _repository.Categori.FirstOrDefault(c => c.CategoriaNome == newCategoria);
                if(fCategory is not null)
                {
                    lanches = _repository.Lanches.Where(l => l.Categoria == fCategory).OrderBy(l => l.Nome);
                    categoriaAtual = fCategory.CategoriaNome;
                }
                else
                {
                    lanches = _repository.Lanches.OrderBy(l => l.LancheId);
                    categoriaAtual = "Todos os lanches";
                }
            }
            LancheListViewModel lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };
            return View(lancheListViewModel);
        }
    }
}
