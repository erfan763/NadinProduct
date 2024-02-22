using Domin.Entities.Product;

namespace Application.Repository;

public interface IProductRepository
{
    Task<Product> GetProductById(string productId);
    Task<Product> AddProduct(Product product);
}