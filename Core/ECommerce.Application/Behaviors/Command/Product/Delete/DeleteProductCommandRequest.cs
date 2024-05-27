using MediatR;

namespace ECommerce.Application.Behaviors.Command.Product.Delete;

public class DeleteProductCommandRequest: IRequest<DeleteProductCommandResponse>
{
    public  int Id { get; set; }
}