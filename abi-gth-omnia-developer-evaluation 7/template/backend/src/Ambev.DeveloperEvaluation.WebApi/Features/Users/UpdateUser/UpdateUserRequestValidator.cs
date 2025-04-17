using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

/// <summary>
/// Validator for UpdateUserRequest
/// </summary>
public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("User ID is required.");
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required.");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required.");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number is required.");
        RuleFor(x => x.Role).IsInEnum().WithMessage("A valid role is required.");
        RuleFor(x => x.Status).IsInEnum().WithMessage("A valid status is required.");
    }
}
