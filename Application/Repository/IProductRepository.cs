using Domin.Entities.Product;

namespace Application.Repository;

public interface IProductRepository
{
    Task<Product> GetProductById(string productId);

    Task<List<Product>> GetAllProducts();

    Task<List<Product>> GetFilteredProductByUser(string userName);

    Task<Product> AddProduct(Product product);

    Task<Product> UpdateProduct(Product product);
}