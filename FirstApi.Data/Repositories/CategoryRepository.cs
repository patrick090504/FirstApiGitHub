using FirstApi.Data.Context;
using FirstApi.Domain.Entities;
using FirstApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Category> GetByIdAsync(int? id)
        {
            return await _context.Categories.FindAsync(id);
            
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
            
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;


        }

        public async Task<Category> DeleteAsync(Category category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }


        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
