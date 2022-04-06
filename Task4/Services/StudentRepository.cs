using Task4.DATA;
using Task4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Task4.Services
{
    public class StudentRepository : IRepository
    {
        private readonly StudentDBContext _context;
        public StudentRepository(StudentDBContext context)
        {
            _context = context;
        }

        public void Add(Student item)
        {
            _context.Students.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {

        }

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Student item)
        {
            using (var connection = new SqlConnection())
            {
                connection.Execute("Update Players SET Name=@PName,Score=@PScore,IsStar=@PIsStar where Id=@PId",
                    new { PId = player.Id, PName = player.Name, PScore = player.Score, PIsStar = player.IsStar });

            }
        }
    }
}