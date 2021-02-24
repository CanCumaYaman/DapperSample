using Dapper;
using DapperExample.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperExample.Dapper.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public string sqlConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DapperExample;Trusted_Connection=true";
       
        public void Add(Student student)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("Insert into Student (FirstName,LastName,Departmant) values (@FirstName, @LastName,@Departmant)", new { FirstName = student.FirstName, LastName = student.LastName, DepartmantName = student.Departmant });
                connection.Close();
                
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("Delete from Student Where Id = @Id", new { Id = id });
                connection.Close();
               
            }
        }

        public List<Student> Find(int id)
        {
            List<Student> students = new List<Student>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                students = connection.Query<Student>("Select Id, FirstName, LastName, Departmant from Student where Id=@Id", new { Id=id }).ToList();
                connection.Close();
            }
            return students;
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                students = connection.Query<Student>("Select * from Student").ToList();
                connection.Close();
            }
            return students;
        }

        public void Update(Student student)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("Update Student set FirstName = @FirstName, LastName = @LastName, Departmant=@Departmant Where Id = @Id", new { Id = student.Id, FirstName=student.FirstName, LastName=student.LastName, Departmant=student.Departmant });
                connection.Close();
               
            }
        }
    }
}
