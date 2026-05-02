using ApiProje.WebApi.Entities;
using FluentValidation;

namespace ApiProje.WebApi.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
          RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez.").MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır.").MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir.");
          RuleFor(p => p.Price).GreaterThan(0).WithMessage("Fiyat sıfırdan büyük olmalıdır.");
          

        }
    }
}
