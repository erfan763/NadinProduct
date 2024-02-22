using AutoMapper;
using Domin.Entities.User;

namespace Application.Features.Users.Commands.Login;

public sealed class LoginMapper : Profile
{
    public LoginMapper()
    {
        CreateMap<User, LoginResponse>();
        CreateMap<LoginResponse, User>();
    }
}