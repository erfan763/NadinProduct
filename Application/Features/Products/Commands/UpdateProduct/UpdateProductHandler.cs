using Application.Repository;
using AutoMapper;
using Domin.Entities.Product;
using MediatR;

namespace Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var updatedProduct = new Product
        {
            Description = request.Description,
            Name = request.ProductName,
            Id = request.productId,
            userId = request.userId,
            IsAvailable = request.IsAvailable
        };
        _mapper.Map<Product>(updatedProduct);
        var product = await _productRepository.UpdateProduct(updatedProduct);
        await _unitOfWork.Save(cancellationToken);
        return _mapper.Map<UpdateProductResponse>(product);
    }
}