using BookApi.Data;
using BookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBookbyId([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContext.Books.Where(b => b.Id.Equals(id)).FirstOrDefault();
            if (book == null)
                return NotFound(); //404 error

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddOneBook([FromBody] Book book)
        {
            try
            {
                if (book == null)
                    return BadRequest("Missing Information");

                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name ="id")] int id, [FromBody] Book book)
        {
            //kitap kontrolu
            var entity = ApplicationContext.Books.Find(b => b.Id == id);

            if (entity == null)
                return NotFound("The book you wanted to update could not be found.");

            if (id != book.Id)
                return BadRequest();

            ApplicationContext.Books.Remove(entity);
            book.Id = entity.Id;
            ApplicationContext.Books.Add(book);
            return Ok(book);
        }

        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            ApplicationContext.Books.Clear();
            return NoContent(); //204
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBookbyId([FromRoute(Name = "id")] int id) 
        { 
            var entity = ApplicationContext.Books.Find(b => b.Id == id);

            if (entity == null)
                return NotFound(new
                {
                    statusCode = 404,
                    message = $"The book you wanted to delete could not be found. id: {id}"
                }); //error 404

            ApplicationContext.Books.Remove(entity);
            return Ok("The book was deleted.");
        }
    }
}
