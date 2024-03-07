using ProductCrudAPI.Domain.Entities;

namespace ProductCrudAPI.Infrastructure.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAllProducts();
    Task<Product> AddProduct(Product product);
    Task<Product> UpdateProduct(Guid productGuid, Product newProduct);
    Task<Product> DeleteProduct(Guid productGuid);
}