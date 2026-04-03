using DBFirstSerilog.Data;
using DBFirstSerilog.DTOs;
using DBFirstSerilog.Models;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBFirstSerilog.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MyAppDbContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(MyAppDbContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }
         
        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetBooks()
        {
            try
            {
                _logger.LogInformation("GET All Books Details");
                var result = await _context.Books
                .Include(b => b.Author)
                .Select(b => new
                {
                    bookId = b.BookId,
                    title = b.Title,
                    genre = b.Genre,
                    publishedYear = b.PublishedYear,
                    authorId = b.AuthorId,
                    author = new
                    {
                        authorId = b.Author.AuthorId,
                        name = b.Author.Name,
                        bio = b.Author.Bio
                    }
                })
                .ToListAsync();

                return Ok(result);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetBook(int id)
        {
            _logger.LogInformation("Fetching book with ID {Id}", id);

            try
            {
                var book = await _context.Books
                    .Where(b => b.BookId == id)
                    .Select(b => new
                    {
                        bookId = b.BookId,
                        title = b.Title,
                        genre = b.Genre,
                        publishedYear = b.PublishedYear,
                        authorId = b.AuthorId,
                        author = b.Author == null ? null : new
                        {
                            authorId = b.Author.AuthorId,
                            name = b.Author.Name,
                            bio = b.Author.Bio
                        }
                    })
                    .FirstOrDefaultAsync();

                if (book == null)
                {
                    _logger.LogWarning("Book with ID {Id} not found", id);
                    return NotFound();
                }

                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching book with ID {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            _logger.LogInformation("Updating book with ID {Id}", id);

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    _logger.LogWarning("Book with ID {Id} not found for update", id);
                    return NotFound();
                }

                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating book with ID {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(CreateBookDto dto)
        {
            _logger.LogInformation("Creating a new book");

            try
            {
                var book = new Book
                {
                    Title = dto.Title,
                    Genre = dto.Genre,
                    PublishedYear = dto.PublishedYear,
                    AuthorId = dto.AuthorId
                };

                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating book");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            _logger.LogInformation("Deleting book with ID {Id}", id);

            try
            {
                var book = await _context.Books.FindAsync(id);

                if (book == null)
                {
                    _logger.LogWarning("Attempt to delete non-existent book ID {Id}", id);
                    return NotFound();
                }

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting book with ID {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
