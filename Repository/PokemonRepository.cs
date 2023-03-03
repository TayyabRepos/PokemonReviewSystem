using PokemonReviewApp.Data;
using PokemonReviewSystem.Interfaces;
using PokemonReviewSystem.Models;

namespace PokemonReviewSystem.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p=>p.Id==id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == p.Name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int id)
        {
            var reviews = _context.Reviews.Where(r => r.Id == id);
            if (reviews.Count()<=0)
                return 0;
            return ((decimal)reviews.Sum(r => r.Rating) / reviews.Count());
        }

        public bool PokemonExists(int id)
        {
            return _context.Pokemon.Any(p=>p.Id==id);
        }
    }
}
