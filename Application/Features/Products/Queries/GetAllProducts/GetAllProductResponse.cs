namespace Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductResponse
{
    public virtual List<ProductDto> Products { get; set; }
}

public class ProductDto
{
    public bool IsAvailable { get; set; } = true;

    public string ManufactureEmail { get; set; }

    public string ManufacturePhone { get; set; }

    public string Description { get; set; }

    public string Name { get; set; }
}