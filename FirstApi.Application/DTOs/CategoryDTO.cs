using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required.")]
        [StringLength(100,MinimumLength = 3)]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
