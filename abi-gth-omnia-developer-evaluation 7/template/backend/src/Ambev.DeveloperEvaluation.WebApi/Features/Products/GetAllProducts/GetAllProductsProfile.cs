using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Products.GetAllProducts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts
{
    /// <summary>
    /// Profile for mapping GetAllProducts feature requests to commands
    /// </summary>
    public class GetAllProductsProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetAllProducts feature
        /// </summary>
        public GetAllProductsProfile()
        {
            CreateMap<GetAllProductsRequest, Application.Products.GetAllProducts.GetAllProductsCommand>()
                .ConstructUsing(_ => new Application.Products.GetAllProducts.GetAllProductsCommand());

            CreateMap<Product, Application.Products.GetAllProducts.GetAllProductsResult>();
        }
    }
}
