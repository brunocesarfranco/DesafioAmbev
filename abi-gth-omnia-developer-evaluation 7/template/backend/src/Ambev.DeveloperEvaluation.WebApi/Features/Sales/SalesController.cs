using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Sales.CreateSale;

using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;


using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class SalesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SalesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new sale
        /// </summary>
        /// <param name="request">Request data for creating a sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response with sale creation result</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateSaleCommand>(request);
            var customerUsername = User?.Identity?.Name;

            if (string.IsNullOrEmpty(customerUsername))
            {
                return Unauthorized(new ApiResponse
                {
                    Success = false,
                    Message = "User is not authenticated"
                });
            }

            // Definir os valores no comando
            command.Customer = customerUsername;
            command.SaleDate = DateTime.UtcNow;


            var response = await _mediator.Send(command, cancellationToken);

            if (response == null)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Sale could not be created"
                });
            }

            return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = _mapper.Map<CreateSaleResponse>(response)
            });
        }


        // /// <summary>
        // /// Retrieves a sale by its ID
        // /// </summary>
        // [HttpGet("{id}")]
        // [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        // public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
        // {
        //     var request = new GetSaleRequest { Id = id };
        //     var validator = new GetSaleRequestValidator();
        //     var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //     if (!validationResult.IsValid)
        //         return BadRequest(validationResult.Errors);

        //     var command = new GetSaleCommand(id);
        //     var response = await _mediator.Send(command, cancellationToken);

        //     if (response == null)
        //         return NotFound(new ApiResponse { Success = false, Message = "Sale not found" });

        //     return Ok(new ApiResponseWithData<GetSaleResponse>
        //     {
        //         Success = true,
        //         Message = "Sale retrieved successfully",
        //         Data = response
        //     });
        // }

        // /// <summary>
        // /// Retrieves all sales
        // /// </summary>
        // [HttpGet("GetAllSales")]
        // [ProducesResponseType(typeof(ApiResponseWithData<GetAllSalesResponse>), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        // public async Task<IActionResult> GetAllSales(CancellationToken cancellationToken)
        // {
        //     var command = new GetAllSalesCommand();
        //     var response = await _mediator.Send(command, cancellationToken);

        //     if (response == null || !response.Sales.Any())
        //         return NotFound(new ApiResponse { Success = false, Message = "No sales found" });

        //     return Ok(new ApiResponseWithData<GetAllSalesResponse>
        //     {
        //         Success = true,
        //         Message = "Sales retrieved successfully",
        //         Data = response
        //     });
        // }
    }
}
