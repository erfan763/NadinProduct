namespace Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductResponse
{
    private string Name { get; set; }

    public string Description { get; set; }

    public string Id { get; set; }

    public string UserId { get; set; }

    public bool IsAvailable { get; set; }

    public string ManufacturePhone { get; set; }

    public string ManufactureEmail { get; set; }
}