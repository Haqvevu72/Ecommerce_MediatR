using ECommerce.Application.Services;
using MediatR;

namespace ECommerce.Application.Behaviors.Command.Product.Delete;

public class DeleteProductCommandHandler: IRequestHandler<DeleteProductCommandRequest , DeleteProductCommandResponse>
{
    private IProductService _productService;


    public DeleteProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _productService.DeleteProductAsync(request);

        return new DeleteProductCommandResponse()
        {
            Message = result ? "Deleted" : "Not Found"
        };
    }
}