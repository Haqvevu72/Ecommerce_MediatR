using ECommerce.Domain.ViewModels;
using System.Net;
using ECommerce.Application.Behaviors.Command.Product.Add;
using ECommerce.Application.Behaviors.Command.Product.Delete;
using ECommerce.Application.Behaviors.Command.Product.Update;

namespace ECommerce.Application.Services;

public interface IProductService
{
    Task<ICollection<GetProductVM>> GetAllProductsAsync(PaginationVM paginationVM);
    Task<GetProductVM?> GetProductByIdAsync(int productId);
    Task AddProductAsync(AddProductCommandRequest request);
    Task<HttpStatusCode> UpdateProductAsync(UpdateProductCommandRequest request);
    Task<bool> DeleteProductAsync(DeleteProductCommandRequest request);
}
