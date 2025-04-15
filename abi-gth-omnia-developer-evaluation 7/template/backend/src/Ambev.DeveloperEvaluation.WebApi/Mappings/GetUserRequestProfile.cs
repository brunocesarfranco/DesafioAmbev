using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class GetUserRequestProfile : Profile
    {
        public GetUserRequestProfile()
        {
            
            CreateMap<GetUserResult, Features.Users.GetUser.GetUserResponse>();
        }
    }
}