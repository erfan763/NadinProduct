using Application.Common;
using Application.Repository;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Queries.GetProductById;

public sealed class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;


    public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper
    )
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductById(request.Id);
        if (product is null) throw new NotFoundException($"product with id {request.Id} not found");
        return _mapper.Map<GetProductByIdResponse>(product);
    }
}