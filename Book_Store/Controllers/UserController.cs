using Business_Layer.Commands.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;
using Model_Layer.QueryModel;
using Repository_Layer.Custom_Exception;
using System.Runtime.InteropServices;

namespace Book_Store.Controllers
{
    [Route("BookStore/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCommandBL userCommandBL;
        private readonly ResponseML responseML;
        public UserController(IUserCommandBL userCommandBL)
        {
            this.userCommandBL = userCommandBL;
            responseML = new ResponseML();
        }

        [HttpPost("Register")]
        public ActionResult RegisterUser(UserModel userModel)
        {
            try
            {
                var result = userCommandBL.RegisterUserAsync(userModel);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Created successfully with id: " + result.Result.UserId;
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
                Console.WriteLine(ex.Message);
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(400, responseML);
            }
        }
    }
}
