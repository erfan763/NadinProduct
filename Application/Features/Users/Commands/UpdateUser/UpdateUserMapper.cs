using Application.Features.Users.Commands.CreateUser;
using AutoMapper;
using Domin.Entities.User;

namespace Application.Features.Users.Commands.UpdateUser;

public sealed class UpdateUserMapper : Profile


{
    public UpdateUserMapper()
    {
        CreateMap<UpdateUserResponse, User>();
        CreateMap<User, UpdateUserResponse>();
    }
}