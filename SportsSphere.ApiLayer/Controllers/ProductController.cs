using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsSphere.DataAccessLayer;
using SportsSphere.DataModels;
using System;

namespace SportsSphere.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // POST: api/Product/CreateProduct
        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                // Call the Data Access Layer to save product information
                DalProducts.SaveProductInfo(product);
                return Ok("Product created successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // DELETE: api/Product/DeleteProduct/5
        [HttpDelete]
        [Route("DeleteProduct/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                // Call the Data Access Layer to delete product information
                DalProducts.DeleteProductInfo(productId);
                return Ok("Product deleted successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // PUT: api/Product/UpdateProduct
        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                // Call the Data Access Layer to update product information
                DalProducts.UpdateProductInfo(product);
                return Ok("Product updated successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // GET: api/Product/GetProducts
        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                // Call the Data Access Layer to retrieve a list of all products
                var products = DalProducts.GetProductInfo();
                return Ok(products);
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // GET: api/Product/GetProductsInCategory/1
        [HttpGet]
        [Route("GetProductsInCategory/{categoryId}")]
        public IActionResult GetProductsInCategory(int categoryId)
        {
            try
            {
                // Call the Data Access Layer to retrieve a list of products in a specific category
                var products = DalProducts.GetProductsInCategory(categoryId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // GET: api/Product/GetProductDetailsById/1
        [HttpGet]
        [Route("GetProductDetailsById/{productId}")]
        public IActionResult GetProductDetailsById(int productId)
        {
            try
            {
                // Call the Data Access Layer to retrieve detailed information for a specific product
                var product = DalProducts.GetProductDetailsById(productId);

                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    // Return 404 Not Found if the product is not found
                    return NotFound($"Product with ID {productId} not found");
                }
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
