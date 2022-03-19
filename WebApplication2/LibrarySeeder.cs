using System.Collections.Generic;
using System.Linq;
using WebApplication2.Entities;

namespace WebApplication2
{
    public class LibrarySeeder
    {
        private readonly LibraryContext libraryContext;

        public LibrarySeeder(LibraryContext context)
        {
            this.libraryContext = context;
        }

        public void Seed()
        {
            if (libraryContext.Database.CanConnect())
            {
                if (!libraryContext.Books.Any())
                {
                    var books = new List<Book>()
                    {
                        new Book()
                        {
                            Title = "Alicja w krainie czarów",
                            ReleasedDate = new System.DateTime(1864, 11, 26),
                            Author = new Author()
                            {
                                Name="Lewis",
                                Surname = "Caroll"
                            }
                        },
                        new Book()
                        {
                            Title = "Mały książe",
                            ReleasedDate = new System.DateTime(1943, 4, 6),
                            Author = new Author()
                            {
                                Name="Antoine",
                                Surname = "de Saint-Exupéry"
                            }
                        }
                    };

                    libraryContext.AddRange(books);
                    libraryContext.SaveChanges();
                }
            }
        }
    }
}
