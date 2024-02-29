using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RefreshToken
{
    public sealed record RefreshTokenRequest : IRequest<RefreshTokenResponse>
    {
        public string RefreshTokenId { get; set; }
        [JsonIgnore] public string userId { get; set; }
    }
}
