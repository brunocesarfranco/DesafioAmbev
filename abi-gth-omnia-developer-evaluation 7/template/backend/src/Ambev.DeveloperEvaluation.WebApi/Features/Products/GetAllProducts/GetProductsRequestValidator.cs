using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Products.GetAllProducts
{
    public class GetAllProductsRequestValidator : AbstractValidator<GetAllProductsRequest>
    {
        public GetAllProductsRequestValidator()
        {
            // Neste caso, como o GetAllProductsRequest não tem propriedades obrigatórias,
            // não há validações a serem feitas.
        }
    }
}
