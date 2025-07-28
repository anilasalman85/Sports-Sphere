using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsSphere.DataAccessLayer;
using SportsSphere.DataModels;
using System;

namespace SportsSphere.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // POST: api/Stock/RefillStock
        [HttpPost]
        [Route("RefillStock")]
        public IActionResult RefillStock([FromBody] StockRefill stockRefill)
        {
            try
            {
                // Call the Data Access Layer to refill stock
                DalStockRefills.SaveStockRefillInfo(stockRefill);
                return Ok("Stock refilled successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with an error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // DELETE: api/Stock/DeleteStockRefill/1
        [HttpDelete]
        [Route("DeleteStockRefill/{refillId}")]
        public IActionResult DeleteStockRefill(int refillId)
        {
            try
            {
                // Call the Data Access Layer to delete stock refill information
                DalStockRefills.DeleteStockRefillInfo(refillId);
                return Ok("Stock refill deleted successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with an error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // PUT: api/Stock/UpdateStockRefill
        [HttpPut]
        [Route("UpdateStockRefill")]
        public IActionResult UpdateStockRefill([FromBody] StockRefill stockRefill)
        {
            try
            {
                // Call the Data Access Layer to update stock refill information
                DalStockRefills.UpdateStockRefillInfo(stockRefill);
                return Ok("Stock refill updated successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with an error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // GET: api/Stock/GetStockRefills
        [HttpGet]
        [Route("GetStockRefills")]
        public IActionResult GetStockRefills()
        {
            try
            {
                // Call the Data Access Layer to retrieve a list of stock refills
                var stockRefills = DalStockRefills.GetStockRefillInfo();
                return Ok(stockRefills);
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with an error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
