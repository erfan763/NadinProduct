using Application.Common;
using Application.Features.Users.Commands.UpdateUser;
using Application.Repository;
using AutoMapper;
using Domin.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace Application.Features.Users.Commands.RefreshToken
{
    public sealed class RefreshTokenHandler : IRequestHandler<RefreshTokenRequest  , RefreshTokenResponse>
    {
        private readonly JWTService _jwtService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public RefreshTokenHandler(IUnitOfWork unitOfWork, IMapper mapper,
            JWTService jwtService, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtService = jwtService;
            _userManager = userManager;
        }


        public async Task<RefreshTokenResponse> Handle(RefreshTokenRequest request , CancellationToken cancellationToken)
        {
            if(request.userId is null) throw new UnauthorizedException("Invalid access token. Please login");
            var currentUser = await _userManager.FindByIdAsync(request.userId);

            if (currentUser is null) throw new NotFoundException("user not found");

            if(currentUser.RefreshToken != request.RefreshTokenId) throw new UnauthorizedException("Token is not valid");


            currentUser.Token = _jwtService.GenrateJWTToken(currentUser.Id, currentUser.UserName);

            await _userManager.UpdateAsync(currentUser);
            _mapper.Map<User>(currentUser);
            await _unitOfWork.Save(cancellationToken);
            return _mapper.Map<RefreshTokenResponse>(currentUser);

        }
    }
}
