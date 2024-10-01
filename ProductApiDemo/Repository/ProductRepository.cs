using ProductApiDemo.Models;

namespace ProductApiDemo.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000, Description = "A high-end laptop" },
            new Product { Id = 2, Name = "Phone", Price = 500, Description = "A smartphone with 5G" }
        };

        public IEnumerable<Product> GetProducts() => _products;

        public Product GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void UpdateProduct(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
            }
        }
    }
}
