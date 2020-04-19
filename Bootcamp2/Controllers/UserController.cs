using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootcamp2.Entities;
using Bootcamp2.Models;
using Bootcamp2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bootcamp2.Controllers
{
    //controller yazmak buraya gelmek için controller yazılmasını zorunlu tutar.
    //action yazmak da zorunlu tutar.
    [Route("[controller]([action]")] 
    public class UserController : Controller
    {
        private readonly UserService _service;
        public UserController(UserService userService)
        {
            _service = userService;
        }
        public IActionResult Index()
        {
            List<UserViewModel> models = new List<UserViewModel>();
            var users = _service.GetAll();
            foreach (UserEntity user in users)
            {
                models.Add(new UserViewModel
                {
                    Id = user.Id,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    Gender = user.Gender,
                    GithubAccountUrl = user.GithubAccountUrl,
                    Name = user.Name,
                    Surname = user.Surname

                });
            }
            return View(models);
        }
        public IActionResult Add()
        {
            var model = new UserViewModel();
            SelectListItem[] genderList = new SelectListItem[]
            {
                new SelectListItem{ Text="Seçiniz"},
                new SelectListItem{ Text = "Kadın", Value = "Femail"},
                new SelectListItem{ Text = "Erkek", Value = "Male"}
            };

            //model.GenderSelectList = genderList;
            ViewData["GenderList"] = genderList;
            return View(model);
        }


        [HttpPost]
        public IActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                SelectListItem[] genderList = new SelectListItem[]
               {
                    new SelectListItem{ Text="Seçiniz"},
                    new SelectListItem{ Text = "Kadın", Value = "Femail"},
                    new SelectListItem{ Text = "Erkek", Value = "Male"}
               };
                model.GenderSelectList = genderList;
                return View(model);
            }
            UserEntity entity = new UserEntity
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                BirthDate = model.BirthDate,
                Email = model.Email,
                GithubAccountUrl = model.GithubAccountUrl,
                Gender = model.Gender
            };
            _service.Add(entity);
            return RedirectToAction(nameof(Index), "User");
        }
        [ResponseCache(Duration = 60)]
        public IActionResult Get(int id)
        {
            UserEntity user = _service.Get(id);
            UserViewModel userVM = new UserViewModel
            {
                Id = user.Id,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Gender = user.Gender,
                GithubAccountUrl = user.GithubAccountUrl,
                Name = user.Name,
                Surname = user.Surname
            };
            return View(userVM);
        }


        //[HttpGet("DetailEdit/{id}")]
        public IActionResult Edit(int id)
        {
            UserEntity user = _service.Get(id);
            UserViewModel userVM = new UserViewModel
            {
                Id = user.Id,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Gender = user.Gender,
                GithubAccountUrl = user.GithubAccountUrl,
                Name = user.Name,
                Surname = user.Surname
            };
            SelectListItem[] genderList = new SelectListItem[]
                {
                    new SelectListItem{ Text="Seçiniz"},
                    new SelectListItem{ Text = "Kadın", Value = "Femail"},
                    new SelectListItem{ Text = "Erkek", Value = "Male"}
                };
            userVM.GenderSelectList = genderList;
            return View(userVM);
        }


        [HttpGet("{id}/{name}/{surname}")]
        public IActionResult Query(int id, string name, string surname)
        {

            var models = new List<UserViewModel>();
            var userEntityList  = _service.Query(id, name, surname);

            foreach (var user in userEntityList)
            {
                models.Add(new UserViewModel
                {
                    Id = user.Id,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    Gender = user.Gender,
                    GithubAccountUrl = user.GithubAccountUrl,
                    Name = user.Name,
                    Surname = user.Surname
                }
                );
            }
            return View("Index", models);
        }
        public IActionResult GetAsJson(int id)
        {
            UserEntity user = _service.Get(id);
            UserViewModel userVM = new UserViewModel
            {
                Id = user.Id,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Gender = user.Gender,
                GithubAccountUrl = user.GithubAccountUrl,
                Name = user.Name,
                Surname = user.Surname
            };
            return Json(userVM);
        }
    }
}