using System.Security.Claims;
using Application.Features.Products.Commands.CreateProduct;
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
    public async Task<ActionResult<CreateProductResponse>> Create(CreateProductRequestInputs requestInputs,
        CancellationToken cancellationToken)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var request = new CreateProductRequest(userId, requestInputs.ProductName, requestInputs.Description);


        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}