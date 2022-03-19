using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public BookController(LibraryContext libraryContext, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
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
            var book = this.mapper.Map<Book>(bookDto);
            this.libraryContext.Add(book);
            this.libraryContext.SaveChanges();
            return Created("/api/books/"+book.Id, null);
        }
    }
}
