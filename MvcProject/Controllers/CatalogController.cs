using Microsoft.AspNetCore.Mvc;
using MvcProject.Models;
using MvcProject.Reposetorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.Controllers
{
    public class CatalogController : Controller
    {
        private IRepository _reposetory;
        public CatalogController(IRepository reposetory)
        {
            _reposetory = reposetory;
        }
        public IActionResult ShowCatalogPage(int id)
        {
            ViewBag.Id = id;
            ViewBag.animal = _reposetory.GetAnimalsByCategoryId(id);
            return View(_reposetory.GetCategories());
        }
        public IActionResult ShowSelectedAnimalPage(int id)
        {
            ViewBag.SelectedAnimal = _reposetory.GetAnimalById(id);
            return View();
        }
        public IActionResult AddComment(int id, Comment comment)
        {            
            if (ModelState.IsValid)
            {
                _reposetory.AddComment(comment.CommentDescription, id);
                return RedirectToAction("ShowSelectedAnimalPage", new { id = id });
            }          
            ViewBag.SelectedAnimal = _reposetory.GetAnimalById(id);
            return View("ShowSelectedAnimalPage");
        }
    }
}
