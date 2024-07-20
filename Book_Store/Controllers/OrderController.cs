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
    [Route("BookStore/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderCommandBL orderCommandBL;
        private readonly IOrderQueryBL orderQueryBL;
        private readonly ResponseML responseML;
        public OrderController(IOrderCommandBL orderCommandBL,IOrderQueryBL orderQueryBL)
        {
            this.orderCommandBL = orderCommandBL;
            responseML = new ResponseML();
            this.orderQueryBL = orderQueryBL;
        }

        [HttpGet("GetUserOrders")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> GetUserOrdersAsync()
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("Id"));
                var result = await orderQueryBL.GetAllOrdersForUserAsync(userId);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Get All Orders Request successful";
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

        [HttpPost("PlaceOrder")]
        [Authorize(Roles ="Customer")]
        public async Task<ActionResult> PlaceOrderAsync(int userDetailsId)
        {
            try
            {
                PlaceOrderModel placeOrderModel = new PlaceOrderModel
                {
                    UserDetailsId = userDetailsId,
                    UserId = Convert.ToInt32(User.FindFirst("Id"))
                };
                var result = await orderCommandBL.PlaceOrderAsync(placeOrderModel);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Order Placed Successfully";
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

        [HttpPost("BuyNow")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> BuyNowAsync(BuyNowModel buyNowModel)
        {
            try
            {
                var result = await orderCommandBL.BuyNowAsync(buyNowModel);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Order Placed Successfully";
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

        [HttpDelete("CancelOrder")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> CancelOrderAsync(int orderId)
        {
            try
            {
                var result = await orderCommandBL.CancelOrderAsync(orderId);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Order cancelled Successfully";
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
