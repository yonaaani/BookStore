using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBookListBLL.DTO;
using MyBookListBLL.Requests;
using MyBookListBLL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBookListBLL.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, Mapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookListDTO>>> GetAllBooks()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookListDTO>> GetBookById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookListDTO>> AddBook([FromBody] AddBookRequest request)
        {
            var bookDTO = _mapper.Map<BookListDTO>(request);
            var addedBookDTO = await _bookService.AddAsync(bookDTO);
            return CreatedAtAction(nameof(GetBookById), new { id = addedBookDTO.Id }, addedBookDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookListDTO>> UpdateBook(int id, [FromBody] UpdateBookRequest request)
        {
            var updatedBook = await _bookService.UpdateAsync(id, request);

            if (updatedBook == null)
            {
                return NotFound();
            }

            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }
    }
}
