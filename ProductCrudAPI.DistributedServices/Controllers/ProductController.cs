using Microsoft.AspNetCore.Mvc;
using ProductCrudAPI.Application.Services.Interfaces;

namespace ProductCrudAPI.DistributedServices.Controllers;

[ApiController]
[Route("ProductAPI")]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly Serilog.ILogger _log;

    public ProductController(IProductService productService, Serilog.ILogger log)
    {
        _productService = productService;
        _log = log;
    }
    
    /// <summary>
    /// Returns all the products in the database
    /// </summary>
    /// <returns>A json with all the products</returns>
    /// <response code="200">Returns 200 and the list of products</response>
    /// <response code="404">Returns 404 if the list is empty</response>
    [HttpGet("ListProducts")]
    public async Task<IActionResult> ListProducts()
    {
        try
        {
            var products = await _productService.GetProductList();
            _log.Information($"Retrieved {products.Count()} products");
            return Ok(products);
        }
        catch (Exception e)
        {
            _log.Error(e.Message);
            return StatusCode(StatusCodes.Status404NotFound);
        }
    }
    
    /// <summary>
    /// Creates and inserts a product into the database
    /// </summary>
    /// <returns>The newly created product</returns>
    /// <response code="200">Returns 200 and the newly created product</response>
    /// <response code="500">Returns 500 if the product isn't created/inserted successfully</response>
    [HttpPut("CreateProduct")]
    public async Task<IActionResult> CreateProduct(string name, string description, double price, Uri image)
    {
        try
        {
            var product = await _productService.CreateProduct(name, description, price, image);
            _log.Information($"Product {product} created successfully");
            return Ok(product);
        }
        catch (Exception e)
        {
            _log.Error(e.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    /// <summary>
    /// Update a product by it's guid
    /// </summary>
    /// <returns>The updated product</returns>
    /// <response code="200">Returns 200 and the updated product</response>
    /// <response code="500">Returns 500 if the product isn't updated/inserted successfully</response>
    [HttpPost("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(Guid productGuid, string name, string description, double price, Uri image)
    {
        try
        {
            var product = await _productService.UpdateProduct(productGuid, name, description, price, image);
            _log.Information($"Product {product} updated successfully");
            return Ok(product);
        }
        catch (Exception e)
        {
            _log.Error(e.Message);
            return StatusCode(StatusCodes.Status404NotFound);
        }
    }
    
    /// <summary>
    /// Delete a product by it's guid
    /// </summary>
    /// <returns>The deleted product</returns>
    /// <response code="200">Returns 200 and the deleted product</response>
    /// <response code="500">Returns 500 if the product isn't deleted successfully</response>
    [HttpDelete("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(Guid productGuid)
    {
        try
        {
            var product = await _productService.DeleteProduct(productGuid);
            _log.Information($"Product {product} deleted successfully");
            return Ok(product);
        }
        catch (Exception e)
        {
            _log.Error(e.Message);
            return StatusCode(StatusCodes.Status404NotFound);
        }
    }
}