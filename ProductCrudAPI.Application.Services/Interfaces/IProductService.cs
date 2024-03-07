using ProductCrudAPI.Domain.Entities;

namespace ProductCrudAPI.Application.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductList();
    Task<Product> CreateProduct(string name, string description, double price, Uri image);
    Task<Product> UpdateProduct(Guid productGuid, string name, string description, double price, Uri image);
    Task<Product> DeleteProduct(Guid productGuid);
}