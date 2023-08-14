using AutoMapper;
using FirstApi.Application.DTOs;
using FirstApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Application.Mappings
{
    public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
