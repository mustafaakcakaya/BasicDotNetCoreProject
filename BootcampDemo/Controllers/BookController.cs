using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootcampDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootcampDemo.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            Book kitap = new Book(1,150,"Orhan Pamuk","Kodluyoruz Yayınevi");

            return View(kitap);
        }
    }
}