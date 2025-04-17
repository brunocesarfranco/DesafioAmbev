using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser
{
    /// <summary>
    /// Handler for processing UpdateUserCommand requests
    /// </summary>
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of UpdateUserHandler
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public UpdateUserHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the UpdateUserCommand request
        /// </summary>
        /// <param name="request">The UpdateUser command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated user details</returns>
        public async Task<UpdateUserResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Validate the input data
            var validator = new UpdateUserValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Retrieve the existing user from the repository
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {request.Id} not found");

            // Update user data
            user.Username = request.Username;
            user.Email = request.Email;
            user.Phone = request.Phone;
            user.Role = request.Role;
            user.Status = request.Status;

            // Save the updated user in the repository
            await _userRepository.UpdateAsync(user, cancellationToken);

            // Map the updated user to the response model
            var response = _mapper.Map<UpdateUserResult>(user);

            return response;
        }
    }

    /// <summary>
    /// Validator for UpdateUserCommand
    /// </summary>
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("User ID is required");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Valid email is required");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Phone is required");
        }
    }
}
