using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Task4.Entities;

namespace Task4.Repos
{
    public class StudentRepo
    {
        public static IWebHostEnvironment WebHost { get; set; }
        public static string TempImgUrl { get; set; }
        public static List<Student> Students { get; set; } = new List<Student>()
        {
            new Student() {Id = 1, Name = "Omar", Surname = "Haciyev", Age = 17, Url = "1.jpg"},
            new Student() {Id = 2, Name = "John", Surname = "Johns", Age = 25, Url = "2.jpg"},
            new Student() {Id = 3, Name = "Lela", Surname = "Hesenli", Age = 15, Url = "3.jpg"},
            new Student() {Id = 4, Name = "FakeName", Surname = "FakeSurname", Age = 55, Url = "4.png"},
        };
    }
}