using DotNet_Core_webApi.Data.Services;
using DotNet_Core_webApi.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Core_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BooksService _booksService;
        public BookController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks =_booksService.GetAllBooks();
            return Ok(allBooks);
        }
        [HttpGet("get-book_by_id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var BookById = _booksService.GetBookById(id);
            return Ok(BookById);
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id , [FromBody] BookVM book)
        {
            var updatedbook = _booksService.UpdateBookById(id, book);
            return Ok(updatedbook);
        }
    }
}
