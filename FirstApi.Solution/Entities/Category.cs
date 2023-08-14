using FirstApi.Domain.Validation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            Validation(name);
        }

        public Category(int id, string name)
        {
            ValidationDomain.When(id < 0, "Invalid id.");
            Id = id;
            Validation(name);
        }

        public void Update(string name)
        {
            Validation(name);
        }
       

        private void Validation(string name)
        {
            ValidationDomain.When(string.IsNullOrEmpty(name), "Name cannot be empty");
            ValidationDomain.When(name.Length < 3, "Name is short, must be at least 3 characters");
            Name = name;
        }
    }
}
