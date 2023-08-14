using FirstApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Application.IServices
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetById(int? id);
        Task<IEnumerable<CategoryDTO>> GetCategories();

        Task Create(CategoryDTO category);
        Task Update(CategoryDTO category);
        Task Delete(int? id);
    }
}
