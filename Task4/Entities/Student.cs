using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Task4.Helpers;
using Task4.Repos;

namespace Task4.Entities
{
    public class Student
    {
        private readonly IWebHostEnvironment _webHost;

        public Student()
        {
            _webHost = StudentRepo.WebHost;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string URL { get; set; }
        public IFormFile File { get; set; }

        public void Update(string name, string surname, int age, string url = null)
        {
            Name = name;
            Surname = surname;
            Age = age;
            if (url != null)
                URL = url;
        }
        public void Create(Student student)
        {
            ID = student.ID;
            Name = student.Name;
            Surname = student.Surname;
            Age = student.Age;
            File = student.File;
            var helper = new ImageHelper(_webHost);
            URL = helper.GetURL(student.File, student.ID);
        }
    }
}