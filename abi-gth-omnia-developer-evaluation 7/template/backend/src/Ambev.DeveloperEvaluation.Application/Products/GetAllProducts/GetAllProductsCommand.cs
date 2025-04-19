using MediatR;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts
{
    /// <summary>
    /// Command for retrieving all products
    /// </summary>
    public record GetAllProductsCommand : IRequest<GetAllProductsResponse>
    {
    }

    /// <summary>
    /// Response model for GetAllProducts operation
    /// </summary>
    public class GetAllProductsResponse
    {
        /// <summary>
        /// List of products
        /// </summary>
        public List<GetAllProductsResult> Products { get; set; } = new List<GetAllProductsResult>();
    }

    /// <summary>
    /// Result model for individual product in GetAllProducts operation
    /// </summary>
    public class GetAllProductsResult
    {
        /// <summary>
        /// The unique identifier of the product
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The title of the product
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The category of the product
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// The quantity of the product in stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The unit price of the product
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The discount applied to the product
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// The total amount after applying discount
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
