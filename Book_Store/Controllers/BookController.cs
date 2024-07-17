using Business_Layer.Commands.Interface;
using Business_Layer.Queries.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer.RequestModel;
using Model_Layer;
using Repository_Layer.Custom_Exception;
using Microsoft.AspNetCore.Authorization;

namespace Book_Store.Controllers
{
    [Route("BookStore/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookCommandBL bookCommandBL;
        private readonly IBookQueryBL bookQueryBL;
        private readonly ResponseML responseML;
        public BookController(IBookCommandBL userCommandBL, IBookQueryBL userQueryBL)
        {
            this.bookCommandBL = userCommandBL;
            this.bookQueryBL = userQueryBL;
            responseML = new ResponseML();
        }

        [HttpGet("GetAllBooks")]
        public async Task<ActionResult> GetAllBooksAsync()
        {
            try
            {
                var result = await bookQueryBL.getAllBookAsync();
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

        [HttpGet("GetBookById/{bookId}")]
        public async Task<ActionResult> GetBookByIdAsync(int bookId)
        {
            try
            {
                var result = await bookQueryBL.getBookByIdAsync(bookId);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Get Book by Book Id Request successful";
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

        [HttpPost("AddBook")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> AddBookAsync(BookModel bookModel)
        {
            try
            {
                var result = await bookCommandBL.AddBookAsync(bookModel);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Book added Successfully";
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

        [HttpPut("UpdateBook/{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateBookAsync(int bookId, BookModel bookModel)
        {
            try
            {
                var result = await bookCommandBL.UpdateBookAsync(bookId, bookModel);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Book Updated Successfully";
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

        [HttpDelete("DeleteBook/{bookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteBookAsync(int bookId)
        {
            try
            {
                var result = await bookCommandBL.DeleteBookAsync(bookId);
                if (result != null)
                {
                    responseML.Success = true;
                    responseML.Message = "Book added Successfully";
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
