using Microsoft.AspNetCore.Mvc;
using MvcProject.Data;
using MvcProject.Reposetorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _reposetory;
        public HomeController(IRepository reposetory)
        {
            _reposetory = reposetory;
        }
        public IActionResult ShowHomePage()
        {
            return View(_reposetory.GetTwoAnimalWithHighComments());
        }
    }
}
