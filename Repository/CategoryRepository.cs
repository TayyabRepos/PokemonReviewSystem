using PokemonReviewApp.Data;
using PokemonReviewSystem.Interfaces;
using PokemonReviewSystem.Models;

namespace PokemonReviewSystem.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        bool ICategoryRepository.CategoryExists(int id)
        {
            return _context.Categories.Any(c=>c.Id == id);
        }

        ICollection<Category> ICategoryRepository.GetCategories()
        {
            return _context.Categories.OrderBy(c=>c.Id).ToList();
        }

        Category ICategoryRepository.GetCategory(int id)
        {
            return _context.Categories.Where(c=>c.Id==id).FirstOrDefault();
        }

        ICollection<Pokemon> ICategoryRepository.GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(c=> c.CategoryId == categoryId)
                .Select(c=>c.Pokemon).ToList();
        }
    }
}
