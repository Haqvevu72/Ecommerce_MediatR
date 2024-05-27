using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ECommerce.Application.Behaviors.Command.Product.Update;

public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
{
    [Required] 
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? Stock { get; set; }

    // Foreign Key
    public int CategoryId { get; set; }
}