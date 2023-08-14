using AutoMapper;
using FirstApi.Application.DTOs;
using FirstApi.Application.IServices;
using FirstApi.Domain.Entities;
using FirstApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<CategoryDTO> GetById(int? id)
        {
            var cat = await _repo.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(cat);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var cat = await _repo.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(cat);

        }

        public async Task Create(CategoryDTO category)
        {
            var cat = _mapper.Map<Category>(category);
            await _repo.CreateAsync(cat);
        }

        public async Task Delete(int? id)
        {
            var cat = await _repo.GetByIdAsync(id);
             await _repo.DeleteAsync(cat);
        }


        public async Task Update(CategoryDTO category)
        {
            var cat = _mapper.Map<Category>(category);
            await _repo.UpdateAsync(cat);
        }
    }
}
