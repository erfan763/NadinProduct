﻿using AutoMapper;
using Domin.Entities.User;

namespace Application.Features.Users.Queries.Users;

public sealed class GetUserMapper : Profile
{
    public GetUserMapper()
    {
        CreateMap<User, GetUserResponse>();
    }
}