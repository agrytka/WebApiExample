using System;
using System.Text.Json.Serialization;

namespace WebApplication2.Models
{
    public class AuthorDto
    {
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
    }
}
