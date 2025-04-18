using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Products.CreateProduct
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O título do produto é obrigatório.")
                .MaximumLength(100).WithMessage("O título do produto não pode exceder 100 caracteres.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("A categoria do produto é obrigatória.")
                .MaximumLength(50).WithMessage("A categoria do produto não pode exceder 50 caracteres.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade não pode ser negativa.")
                .LessThanOrEqualTo(20).WithMessage("Não é permitido vender mais de 20 itens idênticos.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("O preço unitário deve ser maior que zero.");
        }
    }
}