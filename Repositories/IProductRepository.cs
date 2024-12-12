using ProductManagementAPI.DTOs;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Repositories
{
    public interface IProductRepository
    {
        int AddProduct(Product product);
        void DeleteProduct(int id);
        public IEnumerable<Product> GetAllProducts(int page, int PageSize);

        Product GetProductById(int id);
        int GetProductId(string name);
        Product UpdateProduct(int id, ProductInputDTO product);

    }
}