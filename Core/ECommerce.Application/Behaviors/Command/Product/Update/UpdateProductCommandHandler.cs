using System.Net;
using ECommerce.Application.Services;
using MediatR;

namespace ECommerce.Application.Behaviors.Command.Product.Update;

public class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommandRequest , UpdateProductCommandResponse>
{
    private IProductService _productService;

    public UpdateProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request,CancellationToken cancellationToken)
    {
        var result = await _productService.UpdateProductAsync(request);
        var response = new UpdateProductCommandResponse
        {
            Message = result == HttpStatusCode.OK ? "Updated" : "Can not Update"
        };

        return response;

    }
}