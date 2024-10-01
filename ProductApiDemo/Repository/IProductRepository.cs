using ProductApiDemo.Models;

namespace ProductApiDemo.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void UpdateProduct(Product product);
    }
}
