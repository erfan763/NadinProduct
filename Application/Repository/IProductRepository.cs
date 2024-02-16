using Domin.Entities.Product;

namespace Application.Repository;

public interface IProductRepository
{
    Task<Product> GetProductById(int productId);
}