using ProductManagementAPI.DTOs;
using ProductManagementAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductManagementAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts(int page, int PageSize)
        {
            int size = PageSize;
            int number = PageSize * page;
            return _context.Products.OrderByDescending(p => p.DateAdded).Skip(number).Take(PageSize).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.PID == id);
        }

        public int GetProductId(string name)
        {
            var product = _context.Products.FirstOrDefault(p => p.Name == name);
            return product.PID;
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

        public Product UpdateProduct(int id, ProductInputDTO product)
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
            return currentProduct;
        }
    }
}
