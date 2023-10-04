using Lanches.Context;
using Lanches.Models;
using Lanches.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lanches.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);
        public IEnumerable<Categoria> Categori => _context.Categorias.ToList();
        public IEnumerable<Lanche> LanchesPreferidos()
        {
            return _context.Lanches.Where(l => l.IsLanchePreferido == true).Include(c => c.Categoria);
        }
        public Lanche GetLancheById(int id)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == id);
        }
    }
}
