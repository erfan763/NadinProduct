using Application.Repository;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, GetAllProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;


    public GetAllProductHandler(IProductRepository productRepository, IMapper mapper, IUserRepository userRepository
    )
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetAllProductResponse> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
    {
        if (request.creatorUserName is null)
        {
            var productList = await _productRepository.GetAllProducts();
            var productListDto = new List<ProductDto>();
            foreach (var product in productList)
            {
                var productDto = _mapper.Map<ProductDto>(product);
                productListDto.Add(productDto);
            }

            var response = _mapper.Map<GetAllProductResponse>(new GetAllProductResponse { Products = productListDto });
            return response;
        }

        var user = _userRepository.GetUserByUserName(request.creatorUserName);
        if (user.Result is null)
            return _mapper.Map<GetAllProductResponse>(new GetAllProductResponse { Products = null });

        var filteredProduct = await _productRepository.GetFilteredProductByUser(user.Result.UserName);

        var filteredProductDto = new List<ProductDto>();
        foreach (var product in filteredProduct)
        {
            var productDto = _mapper.Map<ProductDto>(product);
            filteredProductDto.Add(productDto);
        }

        var filteredResponse =
            _mapper.Map<GetAllProductResponse>(new GetAllProductResponse { Products = filteredProductDto });

        return filteredResponse;
    }
}