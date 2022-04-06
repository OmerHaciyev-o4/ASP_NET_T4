using System.Collections.Generic;
using Task4.Entities;

namespace Task4.Repos
{
    public class StudentRepo
    {
        public static List<Student> Students { get; set; } = new List<Student>()
        {
            new Student() {ID = 1, Name = "Omer", Surname = "Haciyev", Age = 17, URL = "1.jpg"},
            new Student() {ID = 2, Name = "John", Surname = "Johns", Age = 25, URL = "2.jpg"},
            new Student() {ID = 3, Name = "Lela", Surname = "Hesenli", Age = 15, URL = "3.jpg"},
            new Student() {ID = 4, Name = "FakeName", Surname = "FakeSurname", Age = 55, URL = "4.jpg"},
        };
    }
}
