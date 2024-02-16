using Application.Repository;
using Domin.Entities.Product;
using InferStructure.Context;

namespace InferStructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly AppDbContext _appDbContext;

    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Product> GetProductById(string productId)
    {
        return _appDbContext.Products.FirstOrDefault(x => x.Id == productId);
    }
}