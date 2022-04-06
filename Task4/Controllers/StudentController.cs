using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using Task4.Entities;
using Task4.Helpers;
using Task4.Repos;

namespace Task4.Controllers
{
    public class StudentController : Controller
    {
        public StudentController(IWebHostEnvironment webHost)
        {
            StudentRepo.WebHost = webHost;
        }

        public IActionResult Home()
        {
            ViewBag.Students = StudentRepo.Students;
            return View();
        }

        public IActionResult Delete(string info = null)
        {
            int id = -1;
            if (info != null)
                id = Convert.ToInt32(info);
            else
                return RedirectToAction("home");

            Student deletedStudent = null;
            foreach (var student in StudentRepo.Students)
            {
                if (student.ID == id)
                {
                    deletedStudent = student;
                    break;
                }
            }

            StudentRepo.Students.Remove(deletedStudent);
            return RedirectToAction("home");
        }

        [HttpGet]
        public IActionResult Edit(string info = null)
        {
            try
            {
                int id = Convert.ToInt32(info);
                foreach (var student in StudentRepo.Students)
                {
                    if (student.ID == id)
                    {
                        ViewBag.EditStudent = student;
                        break;
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("home");
            }
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            int id = student.ID;
            Student mainStudent = null;
            foreach (var tempStudent in StudentRepo.Students)
            {
                if (tempStudent.ID == id)
                {
                    mainStudent = student;
                    break;
                }
            }
            string imgURL = null;
            if (student.File != null)
            {
                var helper = new ImageHelper(StudentRepo.WebHost);
                imgURL = helper.GetURL(student.File, student.ID);
            }
            mainStudent.Update(student.Name, student.Surname, student.Age, imgURL);

            return RedirectToAction("home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.ID = StudentRepo.Students.Count + 1;
            Student createdStudent = new Student();
            createdStudent.Create(student);
            StudentRepo.Students.Add(createdStudent);

            return RedirectToAction("home");
        }
    }
}