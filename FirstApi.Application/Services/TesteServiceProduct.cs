using AutoMapper;
using FirstApi.Application.DTOs;
using FirstApi.Application.IServices;
using FirstApi.Domain.Entities;
using FirstApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Application.Services
{
    public class TesteServiceProduct : IProductTeste
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public TesteServiceProduct(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetMaiorPrice(decimal price)
        {
            var prods = await _repo.GetProductsAsync();
            var prodd = prods.Where<Product>(p => p.Price > price).AsEnumerable();
            return _mapper.Map<IEnumerable<ProductDTO>>(prodd);
        }

        public async Task<IEnumerable<ProductDTO>> GetMenorIgualPrice(decimal price)
        {
            var prods = await _repo.GetProductsAsync();
            var prodd = prods.Where<Product>(p => p.Price <= price).AsEnumerable();
            return _mapper.Map<IEnumerable<ProductDTO>>(prodd);
        }

        public async Task<IEnumerable<ProductDTO>> GetMenorIgualStock(int quant)
        {
            var prods = await _repo.GetProductsAsync();
            var prodd = prods.Where<Product>(p => p.Stock <= quant).AsEnumerable();
            return _mapper.Map<IEnumerable<ProductDTO>>(prodd);
        }
    }
}
