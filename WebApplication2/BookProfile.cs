using AutoMapper;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(x => x.BookTitle, map => map.MapFrom(x => x.Title))
                .ForMember(x => x.AuthorName, map => map.MapFrom(x => x.Author.Name))
                .ForMember(x => x.AuthorSurname, map => map.MapFrom(x => x.Author.Surname));

            CreateMap<BookDto, Book>()
                .ForMember(x => x.Title, map => map.MapFrom(x => x.BookTitle))
                .ForPath(x => x.Author.Name, map => map.MapFrom(x => x.AuthorName))
                .ForPath(x => x.Author.Surname, map => map.MapFrom(x => x.AuthorSurname));
        

        }
    }
}
