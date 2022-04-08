using Microsoft.AspNetCore.Http;
using Task4.Entities;

namespace Task4.Models
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public IFormFile File { get; set; }
    } 
}