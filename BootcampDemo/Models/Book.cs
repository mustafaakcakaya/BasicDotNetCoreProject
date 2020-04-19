using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampDemo.Models
{
    public class Book
    {
        public Book(int id, int pageNumber, string author, string publisher)
        {
            Id = id;
            PageNumber = pageNumber;
            Author = author;
            Publisher = publisher;
        }
        public int Id { get; set; }
        public int PageNumber { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

    }
}
