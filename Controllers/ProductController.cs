using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductManagementAPI.DTOs;
using ProductManagementAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace ProductManagementAPI.Controllers
{
    [Authorize]
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
        public IActionResult GetAllProducts(int page, int PageSize)
        {
            try
            {
                return Ok(_productService.GetAllProducts(page, PageSize));
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
