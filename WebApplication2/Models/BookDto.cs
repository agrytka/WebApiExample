using System;
using System.Text.Json.Serialization;

namespace WebApplication2.Models
{
    public class BookDto
    {
 
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }

    }
}
