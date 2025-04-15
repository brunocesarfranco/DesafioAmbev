using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetAllUsers;

/// <summary>
/// Request model for retrieving all users
/// </summary>
public class GetAllUsersRequest
{
}

/// <summary>
/// Validator for GetAllUsersRequest
/// </summary>
public class GetAllUsersRequestValidator : AbstractValidator<GetAllUsersRequest>
{
    public GetAllUsersRequestValidator()
    {
        // No validation rules needed for an empty request
        // Add rules here if query parameters are introduced (e.g., filtering, pagination)
    }
}