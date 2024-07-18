using Business_Layer.Commands.Interface;
using Business_Layer.Queries.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer.RequestModel;
using Model_Layer;
using Repository_Layer.Custom_Exception;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Book_Store.Controllers
{
    [Route("BookStore/Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartCommandBL cartCommandBL;
        private readonly ICartQueryBL cartQueryBL;
        private readonly ResponseML responseML;
        public CartController(ICartCommandBL cartCommandBL,ICartQueryBL cartQueryBL)
        {
            this.cartCommandBL = cartCommandBL;
            responseML = new ResponseML();
            this.cartQueryBL = cartQueryBL;
        }

        [HttpGet("GetUserCarts")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> GetUserCartsAsync()
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("Id"));
                var result = await cartQueryBL.GetAllCartsForUserAsync(userId);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Get All Books Request successful";
                    responseML.Data = result;
                }
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
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(400, responseML);
            }
        }

        [HttpPost("AddToCart")]
        [Authorize(Roles ="Customer")]
        public async Task<ActionResult> AddToCartAsync(int bookId)
        {
            try
            {
                CartModel cartModel = new CartModel
                {
                    BookId = bookId,
                    UserId = Convert.ToInt32(User.FindFirst("Id")),
                };
                var result = await cartCommandBL.AddToCartAsync(cartModel);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Book added to Cart Successfully";
                    responseML.Data = result;
                }
                return StatusCode(201, responseML);
            }
            catch (BookStoreException ex)
            {
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(400, responseML);
            }
            catch (Exception ex)
            {
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(400, responseML);
            }
        }

        [HttpPut("UpdateCart")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> UpdateCartAsync(int cartId, int Quantity)
        {
            try
            {
                var result = await cartCommandBL.UpdateCartAsync(cartId, Quantity);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Quantity Updated Successfully";
                    responseML.Data = result;
                }
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
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(400, responseML);
            }
        }

        [HttpDelete("DeleteCart")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> DeleteBookAsync(int cartId)
        {
            try
            {
                var result = await cartCommandBL.DeleteCartAsync(cartId);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Cart Deleted Successfully";
                    responseML.Data = result;
                }
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
                responseML.Success = false;
                responseML.Message = ex.Message;
                return StatusCode(400, responseML);
            }
        }
    }
}
