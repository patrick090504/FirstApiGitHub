using FirstApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetByIdAsync(int? id);

        Task<Product> GetProductByCategoryIdAsync(int? id);

        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> DeleteAsync(Product product);
    }
}
