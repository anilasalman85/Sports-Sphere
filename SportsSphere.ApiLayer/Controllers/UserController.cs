using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsSphere.DataAccessLayer;
using SportsSphere.DataModels;
using System;

namespace SportsSphere.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // POST: api/User/CreateUser
        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                // Call the Data Access Layer to save user information
                DalUsers.SaveUserInfo(user);
                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // DELETE: api/User/DeleteUser/5
        [HttpDelete]
        [Route("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                // Call the Data Access Layer to delete user information
                DalUsers.DeleteUserInfo(userId);
                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // PUT: api/User/UpdateUser
        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                // Call the Data Access Layer to update user information
                DalUsers.UpdateUserInfo(user);
                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        // GET: api/User/GetUsers
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                // Call the Data Access Layer to retrieve a list of all users
                var users = DalUsers.GetUserInfo();
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Return 500 Internal Server Error with error message if an exception occurs
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
