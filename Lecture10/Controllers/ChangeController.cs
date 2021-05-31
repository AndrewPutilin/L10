using Lecture10.DAL.Domain;
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
    public class ChangeController : Controller
    {
        private readonly ILogger<ChangeController> _logger;
        private readonly IGroupStorage _groupStorage;

        public ChangeController(ILogger<ChangeController> logger, IGroupStorage groupStorage)
        {
            _logger = logger;
            _groupStorage = groupStorage;
        }

        public IActionResult Index(int studentId, int groupId)
        {
            if (groupId > 0)
            {
                return Create(groupId);
            }
            return Edit(studentId);
        }

        public IActionResult Create(int id)
        {
            var model = new StudentEditModel();
            model.AllGroups = _groupStorage.GetAll();
            model.Student = new Student();
            model.SelectedGroup = model.AllGroups.Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = new StudentEditModel();
            model.AllGroups = _groupStorage.GetAll();
            model.Student = _groupStorage.GetStudentGetStudentById(id);
            model.SelectedGroup = model.AllGroups.Where(x => x.Students.Contains(model.Student)).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public IActionResult Save(string flName,int studentId,int groupId)
        {
            if (studentId == 0) 
            {                
                _groupStorage.AddStudent(_groupStorage.GetGroupByIdGroup(groupId), flName);
            }
            else
            {
                _groupStorage.ChangeStudent(_groupStorage.GetGroupByIdGroup(groupId), flName, studentId);
            }

            return Redirect("~/Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

