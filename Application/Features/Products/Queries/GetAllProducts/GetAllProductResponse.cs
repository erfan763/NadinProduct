using Domin.Entities.Product;

namespace Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductResponse
{
    public virtual List<Product> Products { get; set; }
}