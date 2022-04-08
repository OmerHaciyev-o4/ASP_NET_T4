using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Task4.Entities;
using Task4.Helpers;
using Task4.Models;
using Task4.Repos;
using Task4.Services;

namespace Task4.Controllers
{
    public class StudentController : Controller
    {
        private IRepository _repository;
        public StudentController(IWebHostEnvironment webHost, IRepository repository)
        {
            _repository = repository;
            StudentRepo.WebHost = webHost;
        }

        public IActionResult Home()
        {
            ViewBag.Students = _repository.GetAll();
            return View();
        }

        public IActionResult Delete(string info = null)
        {
            Student student = _repository.Get(Convert.ToInt32(info));
            System.IO.File.Delete(Path.Combine(StudentRepo.WebHost.WebRootPath, "images", student.Url));
            _repository.Delete(Convert.ToInt32(info));
            ViewBag.Students = _repository.GetAll();

            return RedirectToAction("home");
        }

        [HttpGet]
        public IActionResult Edit(string info = null)
        {
            int Id = Convert.ToInt32(info);
            ViewBag.EditStudent = _repository.Get(Id);
            StudentRepo.TempImgUrl = _repository.Get(Id).Url;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(StudentViewModel model)
        {
            if (model.File != null)
            {
                var helper = new ImageHelper(StudentRepo.WebHost);
                model.Student.Url = helper.GetURL(model.File, model.Student.Id);
            }
            else
            {
                model.Student.Url = StudentRepo.TempImgUrl;
            }

            _repository.Update(model.Student);
            ViewBag.Students = _repository.GetAll();

            return RedirectToAction("home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel model)
        {
            if (model.File != null)
            {
                var helper = new ImageHelper(StudentRepo.WebHost);
                model.Student.Url = helper.GetURL(model.File, model.Student.Id);
            }
            _repository.Add(model.Student);
            ViewBag.Students = _repository.GetAll();

            return RedirectToAction("home");
        }
    }
}