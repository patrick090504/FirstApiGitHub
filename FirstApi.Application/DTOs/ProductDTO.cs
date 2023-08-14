using FirstApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FirstApi.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required.")]
        [StringLength(100, MinimumLength = 3)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required.")]
        [StringLength(250, MinimumLength = 5)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is Required.")]
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock is Required")]
        [Range(1,9999)]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        [DisplayName("Categories")]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
    }
}
