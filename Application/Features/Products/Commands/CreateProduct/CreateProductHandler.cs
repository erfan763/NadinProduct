using Application.Repository;
using AutoMapper;
using Domin.Entities.Product;
using MediatR;

namespace Application.Features.Products.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var newProduct = new Product
        {
            userId = request.userId,
            Description = request.Description,
            CreatedDate = new DateTime(),
            IsAvailable = true,
            Name = request.ProductName
        };
        _mapper.Map<Product>(newProduct);
        var product = await _productRepository.AddProduct(newProduct);
        await _unitOfWork.Save(cancellationToken);
        return _mapper.Map<CreateProductResponse>(product);
    }
}