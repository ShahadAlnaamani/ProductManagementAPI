using ProductManagementAPI.DTOs;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Repositories
{
    public interface IProductRepository
    {
        int AddProduct(Product product);
        void DeleteProduct(int id);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        int GetProductId(string name);
        Product UpdateProduct(int id, ProductInputDTO product);

    }
}