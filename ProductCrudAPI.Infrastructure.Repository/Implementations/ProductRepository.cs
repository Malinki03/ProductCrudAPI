using ProductCrudAPI.Domain.Entities;
using Serilog;

namespace ProductCrudAPI.Infrastructure.Repository.Implementations;

public class ProductRepository : IProductRepository
{

    private static List<Product> _products = new List<Product>() { new Product {Guid = Guid.NewGuid(), Name = "Samsung 980", Descritpion = "Samsung's 980 m.2 drive", Price = 99.99, Image = new Uri("https://d2g44tvvp35wo2.cloudfront.net/photo/global/2021/03/10/Samsung-NVMe-SSD-980_L-Perspective_DL.jpg")}};
    private readonly ILogger _log;

    public ProductRepository(ILogger log)
    {
        _log = log;
    }
    
    public async Task<IEnumerable<Product>> ListAllProducts()
    {
        return await Task.FromResult(_products);
    }

    public async Task<Product> AddProduct(Product product)
    {
        _products.Add(product);
        return await Task.FromResult(product);
    }

    public async Task<Product> UpdateProduct(Guid productGuid, Product newProduct)
    {
        foreach (Product product in _products)
        {
            if (product.Guid.Equals(productGuid))
            {
                product.Name = newProduct.Name;
                product.Descritpion = newProduct.Descritpion;
                product.Price = newProduct.Price;
                product.Image = newProduct.Image;
            }
        }

        return await Task.FromResult(newProduct);
    }

    public async Task<Product> DeleteProduct(Guid productGuid)
    {
        Product? product = _products.Select(product => product).Where(product => product.Guid == productGuid).First();
        _products.Remove(product);
        return await Task.FromResult(product);
    }
}