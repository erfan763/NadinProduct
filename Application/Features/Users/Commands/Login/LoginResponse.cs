namespace Application.Features.Users.Commands.Login;

public sealed record LoginResponse
{
    public string UserName { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

}