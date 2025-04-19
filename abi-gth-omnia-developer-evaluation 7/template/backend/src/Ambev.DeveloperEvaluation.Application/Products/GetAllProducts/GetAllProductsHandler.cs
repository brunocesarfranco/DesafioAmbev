using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts
{
    /// <summary>
    /// Handler for processing GetAllProductsCommand requests
    /// </summary>
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsCommand, GetAllProductsResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetAllProductsHandler
        /// </summary>
        /// <param name="productRepository">The product repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetAllProductsHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetAllProductsCommand request
        /// </summary>
        /// <param name="request">The GetAllProducts command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of products</returns>
        public async Task<GetAllProductsResponse> Handle(GetAllProductsCommand request, CancellationToken cancellationToken = default)
        {
            // No validation rules needed in this case, but you can add if necessary.
            var products = await _productRepository.GetAllAsync(cancellationToken);

            var response = new GetAllProductsResponse
            {
                Products = _mapper.Map<List<GetAllProductsResult>>(products)
            };

            return response;
        }
    }

    /// <summary>
    /// Validator for GetAllProductsCommand (if needed)
    /// </summary>
    public class GetAllProductsValidator : AbstractValidator<GetAllProductsCommand>
    {
        public GetAllProductsValidator()
        {
            // Add validation rules if needed.
        }
    }
}
