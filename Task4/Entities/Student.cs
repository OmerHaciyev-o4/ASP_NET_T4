using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Task4.Helpers;
using Task4.Repos;

namespace Task4.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Url { get; set; }
    }
}