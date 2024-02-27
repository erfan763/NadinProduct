using Domin.Entities.Product;

namespace Application.Repository;

public interface IProductRepository
{
    Task<Product> GetProductById(string productId);

    Task<List<Product>> GetAllProducts();
    Task<Product> AddProduct(Product product);
}