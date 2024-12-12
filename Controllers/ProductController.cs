using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.DTOs;
using ProductManagementAPI.Services;
using System.Reflection;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(ProductInputDTO product)
        {
            try
            {
                return Ok(_productService.AddNewProduct(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                return Ok(_productService.GetAllProducts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetProductByID {ID}")]
        public IActionResult GetProductByID(int ID)
        {
            try
            {
                return Ok(_productService.GetProductByID(ID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPatch("UpdateProduct {ID}")]
        public IActionResult GetProductByID(int ID, ProductInputDTO product)
        {
            try
            {
                return Ok(_productService.UpdateProduct(product, ID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteProduct {ID}")]
        public IActionResult DeleteProduct(int ID)
        {
            try
            {
                _productService.DeleteProduct(ID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
