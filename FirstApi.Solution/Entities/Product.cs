using FirstApi.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public Product(string name, string description, decimal price, int stock)
        {
            Validation(name, description, price, stock);
        }

        public Product(int id, string name, string description, decimal price, int stock)
        {
            ValidationDomain.When(id < 0, "Invalid id");
            Id = id;
            Validation(name, description, price, stock);
        }

        public void Update(string name, string description, decimal price, int stock, int categoryId)
        {
            Validation(name, description, price, stock);
            CategoryId = categoryId;
        }

        private void Validation(string name, string description, decimal price, int stock)
        {
            ValidationDomain.When(string.IsNullOrEmpty(name), "Name cannot be empty");
            ValidationDomain.When(string.IsNullOrEmpty(description), "Description cannot be empty");
            ValidationDomain.When(name.Length < 3, "Name is short, must be at least 3 characters");
            ValidationDomain.When(description.Length < 5, "Description is short, must be at least 5 characters");
            ValidationDomain.When(price < 0, "Price cannot value negative");
            ValidationDomain.When(stock < 0, "Stock cannot negative");
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
        }


        //Propriedades de Navegação
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
