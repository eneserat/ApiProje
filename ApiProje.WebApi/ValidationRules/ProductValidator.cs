using ApiProje.WebApi.Entities;
using FluentValidation;

namespace ApiProje.WebApi.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez.");
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("Ürün Adı En Az 2 Karakter Olmalıdır.");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Birim Fiyatı 0'dan Büyük Olmalıdır.");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Birim Fiyatı Boş Geçilemez.").LessThan(0).WithMessage("Birim Fiyatı 0'dan Küçük Olamaz.");


        }
    }
}
