using Microsoft.AspNetCore.Mvc;
using Task4.Repos;

namespace Task4.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Home()
        {
            ViewBag.Students = StudentRepo.Students;
            return View();
        }

        [HttpPost]
        public string Details(string info = null)
        {
            return info.ToString();
        }
    }
}