using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsSphere.DataAccessLayer;
using SportsSphere.DataModels;
using System;

namespace SportsSphere.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // POST: api/Categories/CreateCategory
        [HttpPost]
        [Route("CreateCategory")]
        public IActionResult CreateCategory([FromBody] ProductCategory category)
        {
            try
            {
                // Call the Data Access Layer to save product category information
                DalProductCategories.SaveProductCategoryInfo(category);
                return Ok("Product category created successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // DELETE: api/Categories/DeleteCategory/1
        [HttpDelete]
        [Route("DeleteCategory/{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            try
            {
                // Call the Data Access Layer to delete product category information
                DalProductCategories.DeleteProductCategoryInfo(categoryId);
                return Ok("Product category deleted successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // PUT: api/Categories/UpdateCategory
        [HttpPut]
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory([FromBody] ProductCategory category)
        {
            try
            {
                // Call the Data Access Layer to update product category information
                DalProductCategories.UpdateProductCategoryInfo(category);
                return Ok("Product category updated successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // GET: api/Categories/GetCategories
        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            try
            {
                // Call the Data Access Layer to retrieve a list of all product categories
                var categories = DalProductCategories.GetProductCategoryInfo();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
