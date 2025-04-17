using MediatR;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.GetAllUsers;

/// <summary>
/// Command for retrieving all users
/// </summary>
public record GetAllUsersCommand : IRequest<GetAllUsersResponse>
{
}

/// <summary>
/// Response model for GetAllUsers operation
/// </summary>
public class GetAllUsersResponse
{
    /// <summary>
    /// List of users
    /// </summary>
    public List<GetAllUsersResult> Users { get; set; } = new List<GetAllUsersResult>();
}

/// <summary>
/// Result model for individual user in GetAllUsers operation
/// </summary>
public class GetAllUsersResult
{
    /// <summary>
    /// The unique identifier of the user
    /// </summary>
    public Guid Id { get; set; }

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