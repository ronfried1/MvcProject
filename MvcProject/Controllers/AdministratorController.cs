using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;
using MvcProject.Reposetorys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace MvcProject.Controllers
{
    public class AdministratorController : Controller
    {
        private IWebHostEnvironment _environment;
        private IRepository _reposetory;
        string wwwPath;
        public AdministratorController(IRepository reposetory, IWebHostEnvironment environment)
        {
            _reposetory = reposetory;
            _environment = environment;
            wwwPath = this._environment.WebRootPath;
        }
        public IActionResult ShowAdministratorPage(int id)
        {
            ViewBag.Id = id;
            ViewBag.Animal = _reposetory.GetAnimalsByCategoryId(id);

            return View(_reposetory.GetCategories());
        }
        public IActionResult ShowAddNewAnimalPage()
        {
            ViewBag.Categories = _reposetory.GetCategories();
            return View();
        }
        public IActionResult DeleteAnimal(int id)
        {
            Animal animal = _reposetory.GetAnimalById(id);
            _reposetory.DeleteAnimal(id, wwwPath);
            return RedirectToAction("ShowAdministratorPage", new { id = animal.CategoryId });
        }
        public IActionResult AddNewAnimal(Animal animal, IFormFile file)
        {      
            if (ModelState.IsValid & file != null)
            {
                _reposetory.AddNewAnimal(animal, file, wwwPath);
                return RedirectToAction("ShowAdministratorPage", new { id = 2 });
            }
            ViewBag.Categories = _reposetory.GetCategories();
            return View("ShowAddNewAnimalPage");
        }
        public IActionResult ShowEditAnimalPage(int id)
        {       
            ViewBag.Categories = _reposetory.GetCategories();
            return View(_reposetory.GetAnimalById(id));
        }
        public IActionResult EditAnimal(Animal animal, IFormFile file, int id)
        {     
            if (ModelState.IsValid)
            {              
                _reposetory.EditAnimal(animal, file,id, wwwPath);
                return RedirectToAction("ShowSelectedAnimalPage", "Catalog", new { id = id });
            }
            return RedirectToAction("ShowEditAnimalPage", new { id = id });
        }
    }   
}

