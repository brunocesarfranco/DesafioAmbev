using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;

public sealed class AuthenticateUserProfile : Profile
{
    public AuthenticateUserProfile()
    {
        // De User (entidade) para resposta HTTP
        CreateMap<User, AuthenticateUserResponse>()
            .ForMember(dest => dest.Token, opt => opt.Ignore())
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

        // De request HTTP para command da aplicação
        CreateMap<AuthenticateUserRequest, AuthenticateUserCommand>();

        // De resultado da aplicação para resposta HTTP
        CreateMap<AuthenticateUserResult, AuthenticateUserResponse>();
    }
}
