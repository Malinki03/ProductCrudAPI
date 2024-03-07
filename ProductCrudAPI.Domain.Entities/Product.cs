namespace ProductCrudAPI.Domain.Entities;

public class Product
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Descritpion { get; set; }
    public double Price { get; set; }
    public Uri Image { get; set; }
}
