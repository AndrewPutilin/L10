using Lecture10.DAL.MemoryStorage;
using Lecture10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGroupStorage _groupStorage;

        public HomeController(ILogger<HomeController> logger, IGroupStorage groupStorage)
        {
            _logger = logger;
            _groupStorage = groupStorage;
        }

        public IActionResult Index()
        {                 

            return View(_groupStorage.GetAll());
        }        
        public IActionResult Delete(int id)
        {
            _groupStorage.DeleteStudent(id);
            return Redirect("~/Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
