namespace DomainServices
{
    public interface IProductRepository
    {
        IEnumerable<Product>? GetProducts();

        Product? GetProductByName(string name);

        Product? AddProduct(Product newProduct);

        Product? DeleteProduct(Product product);

        Product? UpdateProduct(Product product);
    }
}
