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
            throw new BadRequestException("product with this name already exist");

        _appDbContext.Products.Add(product);
        return product;
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        var exitsProduct = _appDbContext.Products.FirstOrDefault(x => x.Id == product.Id);
        if (exitsProduct is null) throw new NotFoundException("product with this id not found");
        if (exitsProduct.userId != product.userId)
            throw new BadRequestException(
                "you can not change this product because this product did not created by you");
        var user = _appDbContext.Users.FirstOrDefault(x => x.Id == product.userId);
        if (user is null) throw new BadRequestException("user not found");
        if (_appDbContext.Products.Any(x => x.Name == product.Name && x.Id != product.Id))
            throw new BadRequestException("product with this name already exist");
        exitsProduct.Description = product.Description;
        exitsProduct.IsAvailable = product.IsAvailable;
        exitsProduct.Name = product.Name;


        _appDbContext.Products.Update(exitsProduct);
        return exitsProduct;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        var products = _appDbContext.Products.ToList();
        return products;
    }
}