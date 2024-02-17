using MediatR;

namespace Application.Features.Users.Queries.Users;

public sealed record GetUserRequest(string userId) : IRequest<GetUserResponse>;