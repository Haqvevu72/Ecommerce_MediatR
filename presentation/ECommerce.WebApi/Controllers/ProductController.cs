using System.Net;
using ECommerce.Application.Behaviors.Query.Product.GetAll;
using ECommerce.Application.Repositories;
using ECommerce.Application.Services;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Domain.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Text.Json;
using ECommerce.Application.Behaviors.Command.Product.Add;
using ECommerce.Application.Behaviors.Command.Product.Delete;
using ECommerce.Application.Behaviors.Command.Product.Update;

namespace ECommerce.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMediator _mediator;

    public ProductController(IProductService productService, IMediator mediator)
    {
        _productService = productService;
        _mediator = mediator;
    }
    
    // By using service 

    //[HttpGet("AllProducts")]
    //public async Task<IActionResult> GetAll([FromQuery] PaginationVM paginationVM)
    //{
    //    var allProductVm = await _productService.GetAllProductsAsync(paginationVM);
    //    return Ok(allProductVm);
    //}
    
    // [HttpPost("AddProduct")]
    // public async Task<IActionResult> AddProduct([FromBody] AddProductVM productVM)
    // {
    //     if (!ModelState.IsValid)
    //         return BadRequest(ModelState);
    //
    //     await _productService.AddProductAsync(productVM);
    //     return StatusCode(201);
    // }
    
    // [HttpPut("UpdateProduct/{id}")]
    // public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductVM productVM)
    // {
    //     if (!ModelState.IsValid)
    //         return BadRequest(ModelState);
    //
    //     var result = await _productService.UpdateProductAsync(id, productVM);
    //     return StatusCode((int)result);
    // }
    
    // public async Task<IActionResult> DeleteProduct(int id)
    // {
    //     if (await _productService.DeleteProductAsync(id) == false)
    //         return NotFound("Product Not Found");
    //     return StatusCode(204);
    // }
    
    // // Get product (By id)
    // [HttpGet("GetProduct/{id}")]
    // public async Task<IActionResult> GetProduct(int id)
    // {
    //     var productVm = await _productService.GetProductByIdAsync(id);
    //     if (productVm == null)
    //         return NotFound("Product Not Found");
    //     return Ok(productVm);
    // }


    [HttpGet("AllProducts")]
    public async Task<IActionResult> GetAll([FromQuery] GelAllProductQueryRequest request)
    {
        GelAllProductQueryResponse? response = await _mediator.Send(request);
        return response.Products.Count == 0 ? NotFound("Product Not Found") : Ok(response.Products);
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductCommandRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _mediator.Send(request);

        return Ok(response.Message);
    }

    // Delete product (By id)
    [HttpDelete("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct([FromQuery]DeleteProductCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response.Message);
    }
    // Update product (By id)
    [HttpPut("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var response = await _mediator.Send(request);

        return Ok(response.Message);
    }

    // Get product (By id)
    [HttpGet("GetProduct/{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var productVm = await _productService.GetProductByIdAsync(id);
        if (productVm == null)
            return NotFound("Product Not Found");
        return Ok(productVm);
    }
}
