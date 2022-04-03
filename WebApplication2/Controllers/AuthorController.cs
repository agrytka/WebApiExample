using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly LibraryContext libraryContext;
        private readonly IMapper mapper;
        public AuthorController(LibraryContext libraryContext, IMapper mapper)
        {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<Author>> Get()
        {
            var authors = libraryContext.Author.ToList();
            List<AuthorDto> authorsDtos = this.mapper.Map<List<AuthorDto>>(authors);
            return Ok(authorsDtos);    
        }

        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            var authors = libraryContext.Author.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
            if (authors == null)
            {
                return NotFound();
            }
            //AuthorDto authorsDtos = this.mapper.Map<AuthorDto>(authors);
            //return Ok(authorsDtos);
            return Ok(authors);
        }

        [HttpPost]
        public ActionResult Post([FromBody] AuthorDto authorDtos)
        {
            var authors = this.mapper.Map<Author>(authorDtos);
            this.libraryContext.Add(authors);
            this.libraryContext.SaveChanges();
            return Created("/api/authors/" + authors.Id, null);
        }
    }
}
