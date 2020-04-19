using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootcampCalisma2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootcampCalisma2.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            Book kitap = new Book
            {
                Id = 1,
                Author = "Nazım Hikmet",
                Name = "DWQOD",
                PageNumber = 150
            };

            return View(kitap);
        }
    }
}