using AutoMapper;
using FirstApi.Application.DTOs;
using FirstApi.Application.IServices;
using FirstApi.Domain.Entities;
using FirstApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task Add(ProductDTO product)
        {
            var prod = _mapper.Map<Product>(product);
            await _repo.AddAsync(prod);
        }

        public async Task Delete(int? id)
        {
            var prod = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(prod);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var prod = await _repo.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(prod);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var prods = await _repo.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(prods);
        }

        public async Task Update(ProductDTO product)
        {
            var prod = _mapper.Map<Product>(product);
            await _repo.UpdateAsync(prod);
        }
    }
}
