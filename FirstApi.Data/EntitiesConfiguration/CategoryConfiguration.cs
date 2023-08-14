using FirstApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Colocando id sendo a chave 
            //Colocando name com valor max de 100 e sendo requerido, não nullable
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

            builder.HasData(new Category(1, "Material Escolar"),
                new Category(2, "Acessórios"),
                new Category(3, "Livros"));
        }    
    }
}
