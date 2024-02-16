namespace Application.Features.Users.Commands.CreateUser;

public sealed record CreateUserResponse
{
    public string Id { get; set; }
    public string Token { get; set; }
}