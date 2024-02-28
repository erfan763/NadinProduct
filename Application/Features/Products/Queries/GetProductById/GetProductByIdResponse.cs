namespace Application.Features.Products.Queries.GetProductById;

public class GetProductByIdResponse
{
    public bool IsAvailable { get; set; } = true;

    public string ManufactureEmail { get; set; }

    public string ManufacturePhone { get; set; }

    public string Description { get; set; }

    public string Name { get; set; }

    public string userId { get; set; }
}