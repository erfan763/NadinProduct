namespace Application.Features.Users.Commands.UpdateUser;

public sealed record UpdateUserResponse
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string CreatedAt { get; set; }
}