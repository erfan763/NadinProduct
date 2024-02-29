using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RefreshToken
{
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenValidator() {
            RuleFor(x => x.RefreshTokenId).NotEmpty().WithMessage("refresh token id can not be null");
        }
    }
}
