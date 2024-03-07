using ProductCrudAPI.Application.Services.Interfaces;
using ProductCrudAPI.Domain.Entities;
using ProductCrudAPI.Infrastructure.Repository;
using Serilog;

namespace ProductCrudAPI.Application.Services.Implementations;

public class ProductService : IProductService
{

    private readonly IProductRepository _productRepository;
    private readonly ILogger _log;

    public ProductService(IProductRepository productRepository, ILogger log)
    {
        _productRepository = productRepository;
        _log = log;
    }
    
    public async Task<IEnumerable<Product>> GetProductList()
    {
        return await _productRepository.ListAllProducts();
    }

    public async Task<Product> CreateProduct(string name, string description, double price, Uri image)
    {
        Product product = new Product { Guid = Guid.NewGuid(), Name = name, Descritpion = description, Price = price, Image = image};
        return await _productRepository.AddProduct(product);
    }

    public async Task<Product> UpdateProduct(Guid productGuid, string name, string description, double price, Uri image)
    {
        Product product = new Product { Guid = productGuid, Name = name, Descritpion = description, Price = price, Image = image};
        return await _productRepository.UpdateProduct(productGuid, product);
    }

    public async Task<Product> DeleteProduct(Guid productGuid)
    {
        return await _productRepository.DeleteProduct(productGuid);
    }
}