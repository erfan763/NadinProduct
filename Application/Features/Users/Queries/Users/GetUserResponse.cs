namespace Application.Features.Users.Queries.Users;

public class GetUserResponse
{
    public string Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime CreatedDate { get; set; }
}