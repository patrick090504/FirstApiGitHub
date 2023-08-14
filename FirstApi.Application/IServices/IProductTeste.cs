using FirstApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Application.IServices
{
    public interface IProductTeste
    {
        Task<IEnumerable<ProductDTO>> GetMenorIgualStock(int quant);

        Task<IEnumerable<ProductDTO>> GetMenorIgualPrice(decimal price);

        Task<IEnumerable<ProductDTO>> GetMaiorPrice(decimal price);
    }
}
