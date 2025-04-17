using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

/// <summary>
/// Represents the response returned after successfully updating a user.
/// </summary>
/// <remarks>
/// This response contains the updated user information, confirming the applied changes.
/// </remarks>
public class UpdateUserResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the updated user.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the updated name of the user.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the updated password of the user.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the updated phone number of the user.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the updated email address of the user.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the updated status of the user.
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the updated role of the user.
    /// </summary>
    public UserRole Role { get; set; }
}
