using AutoMapper;
using Domin.Entities.User;

namespace Application.Features.Users.Commands.CreateUser;

public sealed class CreateUserMapper : Profile


{
    public CreateUserMapper()
    {
        CreateMap<CreateUserResponse, User>();
        CreateMap<User, CreateUserResponse>();
    }
}