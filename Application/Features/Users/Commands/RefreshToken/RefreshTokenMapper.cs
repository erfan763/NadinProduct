using AutoMapper;
using Domin.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RefreshToken
{
    public sealed class RefreshTokenMapper : Profile
    {
        public RefreshTokenMapper() {
            CreateMap<User, RefreshTokenResponse>();
            CreateMap<RefreshTokenResponse,User>();
        }
    }
}
