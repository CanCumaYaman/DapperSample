using DapperExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperExample.Dapper.Repositories
{
  public  interface IStudentRepository
    {
        List<Student> GetAll();
        List<Student> Find(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
        
    }
}
