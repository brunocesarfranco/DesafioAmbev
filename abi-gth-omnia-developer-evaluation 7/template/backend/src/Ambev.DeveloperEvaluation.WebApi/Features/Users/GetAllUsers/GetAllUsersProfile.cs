using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetAllUsers;

/// <summary>
/// Profile for mapping GetAllUsers feature requests to commands
/// </summary>
public class GetAllUsersProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetAllUsers feature
    /// </summary>
    public GetAllUsersProfile()
    {
        CreateMap<GetAllUsersRequest, Application.Users.GetAllUsers.GetAllUsersCommand>()
            .ConstructUsing(_ => new Application.Users.GetAllUsers.GetAllUsersCommand());

        CreateMap<User, Application.Users.GetAllUsers.GetAllUsersResult>();
    }
}