using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CardFileOfTextMaterialsEpam.BL.Interfaces;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.BL.Models.Auth;
using CardFileOfTextMaterialsEpam.BL.Services;
using CardFileOfTextMaterialsEpam.DAL.Entities.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardFileOfTextMaterialsEpam.PL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly HttpContext _httpContext;

        public AuthorizationController(AuthService authservice, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authservice;
            _httpContext = httpContextAccessor.HttpContext;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthSettings>> GetAllUsers()
        {
            try
            {
                return await _authService.GetAllUsers();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<User> GetUserById(int id)
        {
            try
            {
                return await _authService.GetUserById(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet("byemail/{email}")]
        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                return await _authService.GetUserByEmail(email);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _authService.UpdateUser(user);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            try
            {
                await _authService.DeleteUserById(id);
                return new JsonResult("Deleted Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUpModel user)
        {
            if (user == null)
            {
                return BadRequest("No data was provided");
            }

            try

            {
                await _authService.SignUp(user);
                return new JsonResult("You are registered");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] UserLoginModel user)
        {
            try
            {
                var response = await _authService.SignIn(user);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("signout")]
        public async Task<IActionResult> SignOut()
        {
            try
            {
                await _authService.SignOut();
                var checkAuth = _httpContext.User.Identity.IsAuthenticated;
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("roles/{roleName}")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            try
            {
                await _authService.CreateRole(roleName);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("addRole/{roleName}")]
        public async Task<IActionResult> AddUserToRole([FromBody] string userEmail, string roleName)
        {
            try
            {
                await _authService.AddUserToRole(userEmail, roleName);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetUserRole([FromBody] string email)
        {
            try
            {
                await _authService.GetUserRoles(email);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("card")]
        public async Task<CardModel> GetUserImages([FromBody] string email)
        {
            try
            {
                return await _authService.GetUserCards(email);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}