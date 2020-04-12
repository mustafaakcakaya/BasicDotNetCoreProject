using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootcamp2.Entities;
using Bootcamp2.Models;
using Bootcamp2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bootcamp2.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            var bookEntities = _bookService.GetBooks();
            var bookViewModelList = new List<BookViewModel>();
            foreach (var entity in bookEntities)
            {
                bookViewModelList.Add(new BookViewModel
                {
                    Id = entity.Id,
                    Author = entity.Author,
                    Name = entity.Name,
                    Publisher = entity.Publisher
                });
            }
            return View(bookViewModelList);
        }
        public IActionResult Edit(int id)
        {
            var bookEntity = _bookService.Get(id);
            var bookVM = new BookViewModel()
            {
                Id = bookEntity.Id,
                Author = bookEntity.Author,
                Name = bookEntity.Name,
                Publisher = bookEntity.Publisher
            };
            return View(bookVM);            
        }
        [HttpPost]
        public IActionResult Edit(BookViewModel model)
        {
            var bookEntity = new BookEntity
            {
                Id =model.Id,
                Name = model.Name,
                Author = model.Author,
                Publisher = model.Publisher
            };
            _bookService.Edit(bookEntity);
            var updatedEntity = _bookService.Get(model.Id);
            //NOTE: Still need to improve somethings here and anywhere in project
            //var bookVM = new BookViewModel
            //{
            //    Id = updatedEntity.Id,
            //    Name = updatedEntity.Name,
            //    Author = updatedEntity.Author,
            //    Publisher = updatedEntity.Publisher
            //};

            //return View(bookVM);
            return RedirectToAction(nameof(Index),"Book");
        }
        public IActionResult Delete(BookViewModel model)
        {
            BookEntity entity = new BookEntity {
                Id = model.Id,
                Name = model.Name,
                Author = model.Author,
                Publisher = model.Publisher
            };

            _bookService.Delete(entity);

            return RedirectToAction(nameof(Index),"Book");
        }
        
    }
}