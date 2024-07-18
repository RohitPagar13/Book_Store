using Business_Layer.Commands.Interface;
using Business_Layer.Queries.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;
using Model_Layer.RequestModel;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Entity;
using System.Runtime.InteropServices;

namespace Book_Store.Controllers
{
    [Route("BookStore/Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminCommandBL adminCommandBL;
        private readonly IAdminQueryBL adminQueryBL;
        private readonly ResponseML responseML;
        public AdminController(IAdminCommandBL adminCommandBL, IAdminQueryBL adminQueryBL)
        {
            this.adminCommandBL = adminCommandBL;
            this.adminQueryBL = adminQueryBL;
            responseML = new ResponseML();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAdmin(AdminModel adminModel)
        {
            try
            {
                var result = await adminCommandBL.RegisterAdminAsync(adminModel);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Admin Created successfully with id: " + result.AdminId;
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
        public async Task<ActionResult> LoginAdmin(AdminLoginModel adminLoginModel)
        {
            try
            {
                if (adminLoginModel == null || string.IsNullOrEmpty(adminLoginModel.Email) || string.IsNullOrEmpty(adminLoginModel.Password))
                {
                    return BadRequest("Invalid Login request");
                }

                string? token = await adminQueryBL.LoginAdminAsync(adminLoginModel);
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
    }
}
