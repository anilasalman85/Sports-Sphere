using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsSphere.DataAccessLayer;
using SportsSphere.DataModels;
using System;

namespace SportsSphere.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // POST: api/Admin/CreateAdmin
        [HttpPost]
        [Route("CreateAdmin")]
        public IActionResult CreateAdmin([FromBody] Admin admin)
        {
            try
            {
                // Call the Data Access Layer to save admin information
                DalAdmins.SaveAdminInfo(admin);
                return Ok("Admin created successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // DELETE: api/Admin/DeleteAdmin/5
        [HttpDelete]
        [Route("DeleteAdmin/{adminId}")]
        public IActionResult DeleteAdmin(int adminId)
        {
            try
            {
                // Call the Data Access Layer to delete admin information
                DalAdmins.DeleteAdminInfo(adminId);
                return Ok("Admin deleted successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // PUT: api/Admin/UpdateAdmin
        [HttpPut]
        [Route("UpdateAdmin")]
        public IActionResult UpdateAdmin([FromBody] Admin admin)
        {
            try
            {
                // Call the Data Access Layer to update admin information
                DalAdmins.UpdateAdminInfo(admin);
                return Ok("Admin updated successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // GET: api/Admin/GetAdmins
        [HttpGet]
        [Route("GetAdmins")]
        public IActionResult GetAdmins()
        {
            try
            {
                // Call the Data Access Layer to retrieve a list of all admins
                var admins = DalAdmins.GetAdminInfo();
                return Ok(admins);
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
