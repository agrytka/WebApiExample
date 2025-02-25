﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication2.Models
{
    public class BookDto
    {
        [Required]
        public string BookTitle { get; set; } 

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string AuthorSurname { get; set; }

    }
}
