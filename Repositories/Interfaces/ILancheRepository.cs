using Lanches.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lanches.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos();
        Lanche GetLancheById(int lanchId);
        IEnumerable<Categoria> Categori { get; }
    }
}
