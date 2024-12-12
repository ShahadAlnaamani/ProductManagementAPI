using ProductManagementAPI.DTOs;
using ProductManagementAPI.Models;
using ProductManagementAPI.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductManagementAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public int AddNewProduct(ProductInputDTO product)
        {

            var CompleteProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = DateTime.Now,
            };

            return _productRepository.AddProduct(CompleteProduct);
        }


        public List<ProductOutputDTO> GetProducts()
        {
            var ListofProducts = new List<ProductOutputDTO>();
            foreach (Product product in _productRepository.GetAllProducts())
            {
                var p = ConvertToOutputDTO(product);

                ListofProducts.Add(p);
            }
            return ListofProducts;
        }


        public ProductOutputDTO GetProductByID(int id)
        {
            var product = _productRepository.GetProductById(id);

            //Mapping the product (Product to DTO)
            var p = new ProductOutputDTO
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = product.DateAdded,
            };

            return p;
        }


        public ProductOutputDTO UpdateProduct(ProductInputDTO product, int ID)
        {
            var updatedProduct = _productRepository.UpdateProduct(ID, product);

            return ConvertToOutputDTO(updatedProduct);
        }

        public void DeleteProduct(int ID)
        {
            _productRepository.DeleteProduct(ID);
        }


        public ProductOutputDTO ConvertToOutputDTO(Product product)
        {
            var p = new ProductOutputDTO
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = DateTime.Now,
            };
            return p;
        }


        public Product ConvertToProduct(ProductInputDTO productDTO)
        {
            int ID = _productRepository.GetProductId(productDTO.Name);
            var p = new Product
            {
                PID = ID,
                Name = productDTO.Name,
                Price = productDTO.Price,
                Category = productDTO.Category,
                DateAdded = DateTime.Now,
            };
            return p;
        }
    }
}
