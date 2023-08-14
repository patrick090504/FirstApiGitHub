using FirstApi.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace TestUnitDomain
{
    public class CategoryTest
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState() // Função, tipo do teste, resultado
        {
            Action action = () => new Category(1, "Category name");
            action.Should().NotThrow<FirstApi.Domain.Validation.ValidationDomain>();
        }

        [Theory]
        [InlineData(-5)] // teste com parâmetro
        public void CreateCategory_WithIdInvalid_ExceptionInvalidId(int value)
        {
            Action action = () => new Category(value, "Patrick");
            action.Should().Throw<FirstApi.Domain.Validation.ValidationDomain>().WithMessage("Invalid Id.");
        }

        //Depois termino
    }
}
