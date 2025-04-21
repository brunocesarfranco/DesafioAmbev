using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateSaleHandler(ISaleRepository saleRepository, IProductRepository productRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            // Mapeia o comando para a entidade Sale
            var sale = new Sale(request.Customer, request.SaleDate);

            foreach (var itemRequest in request.Items)
            {
                var product = await _productRepository.GetByIdAsync(itemRequest.ProductId, cancellationToken);
                if (product == null)
                {
                    throw new KeyNotFoundException($"Produto com ID {itemRequest.ProductId} não encontrado.");
                }

                var item = new ItemSale(product.Id, itemRequest.Quantity, product.UnitPrice, product, sale);
                item.ApplyDiscount();
                sale.Items.Add(item);
            }

            sale.CalculateTotalAmount();

            // Persiste a venda
            await _saleRepository.CreateAsync(sale, cancellationToken);

            return _mapper.Map<CreateSaleResult>(sale);
        }
    }
}
