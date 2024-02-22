using Application.Common;
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

    public async Task<Product> AddProduct(Product product)
    {
        var user = _appDbContext.Users.FirstOrDefault(x => x.Id == product.userId);
        product.User = user;
        product.ManufactureEmail = user.Email;
        product.ManufacturePhone = user.PhoneNumber;

        if (_appDbContext.Products.Any(x => x.Name == product.Name))
        {
            throw new BadRequestException("product with this name already exist");
        }

        _appDbContext.Products.Add(product);
        return product;
    }
}