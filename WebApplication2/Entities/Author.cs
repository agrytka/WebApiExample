using System.Collections.Generic;

namespace WebApplication2.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual List<Book> Books {get; set;}
    }
}
