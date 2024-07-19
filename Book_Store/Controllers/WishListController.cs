using Business_Layer.Commands.Interface;
using Business_Layer.Queries.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer.RequestModel;
using Model_Layer;
using Repository_Layer.Custom_Exception;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Business_Layer.Commands.Implementation;

namespace Book_Store.Controllers
{
    [Route("BookStore/WishList")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListCommandBL wishListCommandBL;
        private readonly IWishListQueryBL wishListQueryBL;
        private readonly ResponseML responseML;
        public WishListController(IWishListCommandBL wishListCommandBL, IWishListQueryBL wishListQueryBL)
        {
            this.wishListCommandBL = wishListCommandBL;
            this.wishListQueryBL = wishListQueryBL;
            responseML = new ResponseML();
        }

        [HttpGet("GetUserWishList")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> GetUserWishListAsync()
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("Id"));
                var result = await wishListQueryBL.GetAllWishListForUserAsync(userId);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Get WishList Request successful";
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

        [HttpPost("AddToWishList")]
        [Authorize(Roles ="Customer")]
        public async Task<ActionResult> AddToWishListAsync(int bookId)
        {
            try
            {
                WishListModel wishListModel = new WishListModel
                {
                    BookId = bookId,
                    UserId = Convert.ToInt32(User.FindFirst("Id")),
                };
                var result = await wishListCommandBL.addToWishListAsync(wishListModel);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Book added to WishList Successfully";
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


        [HttpDelete("DeleteFromWishList")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> DeleteFromWishListAsync(int wishListId)
        {
            try
            {
                var result = await wishListCommandBL.removeFromWishListAsync(wishListId);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Item from WishList Deleted Successfully";
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
