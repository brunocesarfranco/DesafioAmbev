using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Products.GetProduct
{
    public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
    {
        public GetProductRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID do produto é obrigatório.");
        }
    }
}
