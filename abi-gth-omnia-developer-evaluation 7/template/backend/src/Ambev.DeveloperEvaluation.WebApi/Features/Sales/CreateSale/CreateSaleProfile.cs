using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Sales.CreateSale
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            // Mapeamento entre CreateSaleRequest e CreateSaleCommand
            CreateMap<CreateSaleRequest, CreateSaleCommand>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            // Mapeamento entre CreateSaleResult e CreateSaleResponse
            CreateMap<CreateSaleResult, CreateSaleResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items)); // Mapeamento para os itens

            // Mapeamento entre CreateItemSaleRequest e CreateSaleItemRequest
            CreateMap<CreateItemSaleRequest, CreateSaleItemRequest>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            // Mapeamento entre ItemSale e CreateSaleItemResult
            CreateMap<ItemSale, CreateSaleItemResult>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount));

            // Mapeamento entre CreateSaleItemResult e CreateSaleItemResponse
            CreateMap<CreateSaleItemResult, CreateSaleItemResponse>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.ProductTitle, opt => opt.MapFrom(src => src.ProductTitle))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount));
        }
    }
}
