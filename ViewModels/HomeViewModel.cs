using Lanches.Models;

namespace Lanches.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchPreferidos { get; set; }
        public IEnumerable<Lanche> Lanches { get; set; }
    }
}
