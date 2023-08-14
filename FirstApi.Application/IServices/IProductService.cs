using FirstApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Application.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(int? id);

        Task Add(ProductDTO product);
        Task Update(ProductDTO product);
        Task Delete(int? id);
        
    }
}
