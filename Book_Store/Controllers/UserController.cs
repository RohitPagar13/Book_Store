using Business_Layer.Commands.Interface;
using Business_Layer.Queries.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;
using Model_Layer.RequestModel;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Entity;
using System.Runtime.InteropServices;

namespace Book_Store.Controllers
{
    [Route("BookStore/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCommandBL userCommandBL;
        private readonly IUserQueryBL userQueryBL;
        private readonly ResponseML responseML;
        public UserController(IUserCommandBL userCommandBL, IUserQueryBL userQueryBL)
        {
            this.userCommandBL = userCommandBL;
            this.userQueryBL = userQueryBL;
            responseML = new ResponseML();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(UserModel userModel)
        {
            try
            {
                var result = await userCommandBL.RegisterUserAsync(userModel);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Created successfully with id: " + result.UserId;
                    responseML.Data = result;
                }
                return StatusCode(201, responseML);
            }
            catch (BookStoreException ex)
            {
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(202, responseML);
            }
            catch (Exception ex)
            {
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(400, responseML);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginUser(UserLoginModel userLoginModel)
        {
            try
            {
                if (userLoginModel == null || string.IsNullOrEmpty(userLoginModel.Email) || string.IsNullOrEmpty(userLoginModel.Password))
                {
                    return BadRequest("Invalid Login request");
                }

                string? token = await userQueryBL.LoginUserAsync(userLoginModel);
                if (token != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Login successful";
                    responseML.Data = token;
                }
                else
                {
                    responseML.Success = false;
                    responseML.Message = "Unable to Login Please try again";
                }
                return StatusCode(200, responseML); 
            }
            catch (BookStoreException ex)
            {
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(202, responseML);
            }
            catch (Exception ex)
            {
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(400, responseML);
            }
        }

        [HttpGet]
        [Route("ForgotUser/{email}")]
        public IActionResult ForgotUser(string email)
        {
            try
            {
                string successfulMail = userQueryBL.ForgetPasswordAsync(email).Result;

                responseML.Success = true;
                responseML.Message = "Request Successful, email has been sent to email: "+ successfulMail;
                return StatusCode(200, responseML);
            }
            catch (BookStoreException ex)
            {
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(400, responseML);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(400, responseML);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("ResetUser")]
        public IActionResult ResetUser([FromBody] string password)
        {
            try
            {
                string Email = User.FindFirst("Email").Value;
                string successfulMail = userCommandBL.ResetPasswordAsync(Email, password).Result;
                responseML.Success = true;
                responseML.Message = "Request Successful, password reset successful for email: "+successfulMail;
                return StatusCode(200, responseML);
            }
            catch (BookStoreException ex)
            {
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(400, responseML);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(400, responseML);
            }
        }
    }
}
