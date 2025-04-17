using MediatR;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser
{
    /// <summary>
    /// Command for updating an existing user
    /// </summary>
    public record UpdateUserCommand : IRequest<UpdateUserResult>
    {

        /// <summary>
        /// Gets or sets the unique identifier of the updated user.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Gets or sets the password for the user.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// The user's full name
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// The user's email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The user's phone number
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// The user's role in the system
        /// </summary>
        public UserRole Role { get; set; }

        /// <summary>
        /// The current status of the user
        /// </summary>
        public UserStatus Status { get; set; }
    }
}
