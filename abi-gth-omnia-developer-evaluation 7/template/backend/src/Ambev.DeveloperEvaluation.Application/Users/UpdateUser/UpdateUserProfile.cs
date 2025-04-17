using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser
{
    /// <summary>
    /// Profile for mapping UpdateUser feature requests to commands
    /// </summary>
    public class UpdateUserProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateUser feature
        /// </summary>
        public UpdateUserProfile()
        {
            CreateMap<UpdateUserResult, UpdateUserCommand>()
                .ConstructUsing(_ => new UpdateUserCommand());

            CreateMap<User, UpdateUserResult>();
        }
    }
}
