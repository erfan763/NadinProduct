using MediatR;

namespace Application.Features.Users.Commands.Login;

public sealed record LoginRequest(string UserName, string Password) : IRequest<LoginResponse>;