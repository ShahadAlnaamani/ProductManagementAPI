using ProductManagementAPI.DTOs;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public interface IProductService
    {
        int AddNewProduct(ProductInputDTO product);
        ProductOutputDTO ConvertToOutputDTO(Product product);
        Product ConvertToProduct(ProductInputDTO productDTO);
        void DeleteProduct(int ID);
        ProductOutputDTO GetProductByID(int id);
        List<ProductOutputDTO> GetProducts();
        ProductOutputDTO UpdateProduct(ProductInputDTO product, int ID);
    }
}