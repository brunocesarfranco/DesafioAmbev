using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("A lista de itens da venda não pode estar vazia.");

            RuleForEach(x => x.Items)
                .ChildRules(items =>
                {
                    items.RuleFor(x => x.ProductId)
                        .NotEmpty().WithMessage("O ID do produto é obrigatório.")
                        .MustAsync(async (productId, cancellationToken) => await ProductExistsAsync(productId, cancellationToken))
                        .WithMessage("Produto não encontrado.");

                    items.RuleFor(x => x.Quantity)
                        .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.")
                        .LessThanOrEqualTo(20).WithMessage("Não é permitido vender mais de 20 itens do mesmo produto.");
                });
        }

        // Método assíncrono para verificar se o produto existe no banco de dados
        private async Task<bool> ProductExistsAsync(Guid productId, CancellationToken cancellationToken)
        {
            // Substitua com a lógica para verificar a existência do produto no banco de dados
            // Exemplo: return await _productRepository.ExistsAsync(productId);
            return true; // Placeholder, deve ser implementado
        }
    }
}
