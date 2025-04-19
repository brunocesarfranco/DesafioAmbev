using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories;

// using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
// using Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;
// using Ambev.DeveloperEvaluation.Application.Products.GetProductByCategory;
// using Ambev.DeveloperEvaluation.Application.Products.GetProductById;
// using Ambev.DeveloperEvaluation.Application.Products.GetProductByTitle;
// using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

using Ambev.DeveloperEvaluation.WebApi.Common;
// using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
// using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
// using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;
// using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductByCategory;
// using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductById;
// using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductByTitle;
// using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Products.GetAllProducts;
using Ambev.DeveloperEvaluation.WebApi.Products.GetProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products
{
    /// <summary>
    /// Controller for managing product operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class ProductsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of ProductsController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public ProductsController(IMediator mediator, IMapper mapper, IProductRepository productRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _productRepository =  productRepository;
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="request">The product creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateProductCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
            {
                Success = true,
                Message = "Product created successfully",
                Data = _mapper.Map<CreateProductResponse>(response)
            });
        }

        /// <summary>
        /// Retrieves a product by its ID
        /// </summary>
        /// <param name="id">The unique identifier of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetProductResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        // [Authorize]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetProductRequest { Id = id };
            var validator = new GetProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Invalid request",
                    Errors = validationResult.Errors
                        .Select(e => new ValidationErrorDetail
                        {
                            Detail = e.PropertyName,
                            Error = e.ErrorMessage
                        })
                        .ToList()
                });
            }

            var command = new GetProductCommand(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            if (response == null)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Product not found"
                });
            }

            return Ok(new ApiResponseWithData<GetProductResult>
            {
                Success = true,
                Message = "Product retrieved successfully",
                Data = response
            });
        }


        /// <summary>
        /// Retrieves all products
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of all products</returns>
        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetAllProductsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        // 
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
        {
            // Criando um comando para recuperar todos os produtos
            var command = new GetAllProductsCommand();
            var response = await _mediator.Send(command, cancellationToken);

            // Verifica se a lista de produtos está vazia
            if (response == null || !response.Products.Any())
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "No products found"
                });
            }

            return Ok(new ApiResponseWithData<GetAllProductsResponse>
            {
                Success = true,
                Message = "Products retrieved successfully",
                Data = response
            });
        }

        // /// <summary>
        // /// Retrieves products by category
        // /// </summary>
        // /// <param name="category">The category of the products</param>
        // /// <param name="cancellationToken">Cancellation token</param>
        // /// <returns>List of products in the specified category</returns>
        // [HttpGet("category/{category}")]
        // [ProducesResponseType(typeof(ApiResponseWithData<GetProductByCategoryResponse>), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        // public async Task<IActionResult> GetProductByCategory([FromRoute] string category, CancellationToken cancellationToken)
        // {
        //     var request = new GetProductByCategoryRequest { Category = category };
        //     var validator = new GetProductByCategoryRequestValidator();
        //     var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //     if (!validationResult.IsValid)
        //         return BadRequest(validationResult.Errors);

        //     var command = new GetProductByCategoryQuery(category);
        //     var response = await _mediator.Send(command, cancellationToken);

        //     return Ok(new ApiResponseWithData<GetProductByCategoryResponse>
        //     {
        //         Success = true,
        //         Message = "Products retrieved successfully",
        //         Data = response
        //     });
        // }

        // /// <summary>
        // /// Updates an existing product
        // /// </summary>
        // /// <param name="request">The updated product information, including ID</param>
        // /// <param name="cancellationToken">Cancellation token</param>
        // /// <returns>The updated product details</returns>
        // [HttpPut]
        // [ProducesResponseType(typeof(ApiResponseWithData<UpdateProductResponse>), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        // public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
        // {
        //     var validator = new UpdateProductRequestValidator();
        //     var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //     if (!validationResult.IsValid)
        //         return BadRequest(validationResult.Errors);

        //     var command = _mapper.Map<UpdateProductCommand>(request);
        //     var response = await _mediator.Send(command, cancellationToken);

        //     if (response == null)
        //         return NotFound(new ApiResponse
        //         {
        //             Success = false,
        //             Message = "Product not found"
        //         });

        //     return Ok(new ApiResponseWithData<UpdateProductResponse>
        //     {
        //         Success = true,
        //         Message = "Product updated successfully",
        //         Data = _mapper.Map<UpdateProductResponse>(response)
        //     });
        // }

        // /// <summary>
        // /// Deletes a product by its ID
        // /// </summary>
        // /// <param name="id">The unique identifier of the product to delete</param>
        // /// <param name="cancellationToken">Cancellation token</param>
        // /// <returns>Success response if the product was deleted</returns>
        // [HttpDelete("{id}")]
        // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        // public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken)
        // {
        //     var request = new DeleteProductRequest { Id = id };
        //     var validator = new DeleteProductRequestValidator();
        //     var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //     if (!validationResult.IsValid)
        //         return BadRequest(validationResult.Errors);

        //     var command = new DeleteProductCommand(id);
        //     var response = await _mediator.Send(command, cancellationToken);

        //     if (!response)
        //         return NotFound(new ApiResponse
        //         {
        //             Success = false,
        //             Message = "Product not found"
        //         });

        //     return Ok(new ApiResponse
        //     {
        //         Success = true,
        //         Message = "Product deleted successfully"
        //     });
        // }

        // /// <summary>
        // /// Retrieves a product by its title
        // /// </summary>
        // /// <param name="title">The title of the product</param>
        // /// <param name="cancellationToken">Cancellation token</param>
        // /// <returns>The product details if found</returns>
        // [HttpGet("title/{title}")]
        // [ProducesResponseType(typeof(ApiResponseWithData<GetProductByTitleResult>), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        // public async Task<IActionResult> GetProductByTitle([FromRoute] string title, CancellationToken cancellationToken)
        // {
        //     var request = new GetProductByTitleRequest { Title = title };
        //     var validator = new GetProductByTitleRequestValidator();
        //     var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //     if (!validationResult.IsValid)
        //         return BadRequest(validationResult.Errors);

        //     var command = new GetProductByTitleQuery(title);
        //     var response = await _mediator.Send(command, cancellationToken);

        //     if (response == null)
        //         return NotFound(new ApiResponse
        //         {
        //             Success = false,
        //             Message = "Product not found"
        //         });

        //     return Ok(new ApiResponseWithData<GetProductByTitleResult>
        //     {
        //         Success = true,
        //         Message = "Product retrieved successfully",
        //         Data = response
        //     });
        // }
    }
}