using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Users.GetAllUsers;

/// <summary>
/// Handler for processing GetAllUsersCommand requests
/// </summary>
public class GetAllUsersHandler : IRequestHandler<GetAllUsersCommand, GetAllUsersResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetAllUsersHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public GetAllUsersHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetAllUsersCommand request
    /// </summary>
    /// <param name="request">The GetAllUsers command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of users</returns>
    public async Task<GetAllUsersResponse> Handle(GetAllUsersCommand request, CancellationToken cancellationToken = default)
    {
        var validator = new GetAllUsersValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var users = await _userRepository.GetAllAsync(cancellationToken);

        var response = new GetAllUsersResponse
        {
            Users = _mapper.Map<List<GetAllUsersResult>>(users)
        };

        return response;
    }
}

/// <summary>
/// Validator for GetAllUsersCommand
/// </summary>
public class GetAllUsersValidator : AbstractValidator<GetAllUsersCommand>
{
    public GetAllUsersValidator()
    {
        // Add validation rules if needed
    }
}