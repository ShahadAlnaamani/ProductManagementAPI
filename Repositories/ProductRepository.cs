using ProductManagementAPI.Models;

namespace ProductManagementAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.PID == id);
        }

        public int AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.PID;
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public void UpdateProduct(int id, Product product)
        {
            var currentProduct = GetProductById(id);
            if (currentProduct != null)
            {
                currentProduct.Name = product.Name;
                currentProduct.Price = product.Price;
                currentProduct.Category = product.Category;

                _context.Products.Update(currentProduct);
                _context.SaveChanges();
            }
        }
    }
}
