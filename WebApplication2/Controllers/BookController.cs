using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext libraryContext;
        private readonly IMapper mapper;
        private readonly ILogger<BookController> logger;

        public BookController(LibraryContext libraryContext, IMapper mapper, ILogger<BookController> logger)
        {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            var books =  libraryContext.Books.Include(x => x.Author).ToList();
            List<BookDto> bookDtos = this.mapper.Map<List<BookDto>>(books);
            return Ok(bookDtos);
        }
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            //throw new System.Exception("TEST"); // metoda 1
            logger.LogInformation("Test1"); // metoda2
            var book = libraryContext.Books.Include(x => x.Author).FirstOrDefault(x => x.Id == id);
            if(book == null)
            {
                return NotFound();
            }
            BookDto bookDto = this.mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        [HttpPost]
        public ActionResult Post([FromBody]BookDto bookDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = this.mapper.Map<Book>(bookDto);
            this.libraryContext.Add(book);
            this.libraryContext.SaveChanges();
            return Created("/api/books/"+book.Id, null);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]BookDto bookDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = libraryContext.Books.Include(x => x.Author).FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = bookDto.BookTitle;
            book.Author.Name = bookDto.AuthorName;
            book.Author.Surname = bookDto.AuthorSurname;
            this.libraryContext.SaveChanges();
            return NoContent();




        }
        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            var book = libraryContext.Books.Include(x => x.Author).FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            this.libraryContext.Books.Remove(book);
            this.libraryContext.SaveChanges();
            return NoContent();
        }
    }
}
