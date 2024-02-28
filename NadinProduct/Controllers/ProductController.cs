using System.Security.Claims;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NadinProduct.Controllers;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("createProduct")]
    [Authorize]
    public async Task<ActionResult<CreateProductResponse>> Create(CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        request.userId = userId;
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("createProduct/{productId}")]
    [Authorize]
    public async Task<ActionResult<UpdateProductResponse>> Update(string productId, UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        request.userId = userId;
        request.productId = productId;
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpGet("getAllProduct")]
    public async Task<ActionResult<GetAllProductResponse>> GetAllProduct(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllProductRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("getProductById/{productId}")]
    public async Task<ActionResult<GetProductByIdResponse>> GetProductById(string productId,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetProductByIdRequest(productId), cancellationToken);
        return Ok(response);
    }
}