using Business_Layer.Commands.Interface;
using Business_Layer.Queries.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer.RequestModel;
using Model_Layer;
using Repository_Layer.Custom_Exception;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Authorization;

namespace Book_Store.Controllers
{
    [Route("BookStore/[UserDetails]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsCommandBL userDetailsCommandBL;
        private readonly ResponseML responseML;
        public UserDetailsController(IUserDetailsCommandBL userCommandBL)
        {
            this.userDetailsCommandBL = userCommandBL;
            responseML = new ResponseML();
        }

        [HttpPost("Add")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> RegisterUser(UserDetailsModel userDetailsModel)
        {
            try
            {
                var result = await userDetailsCommandBL.addUserDetailsAsync(new UserDetailsClaimsModel
                {
                    AddressType = userDetailsModel.AddressType,
                    AddressLine = userDetailsModel.AddressLine,
                    LandMark = userDetailsModel.LandMark,
                    City = userDetailsModel.City,
                    Country = userDetailsModel.Country,
                    ZipCode = userDetailsModel.ZipCode,
                    UserId = Convert.ToInt32(User.FindFirst("Id")?.Value),
                });
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "User Details added successfully with id: " + result.UserId;
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
    }
}
