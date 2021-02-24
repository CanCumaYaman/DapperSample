using Dapper;
using DapperExample.Dapper.Repositories;
using DapperExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DapperExample.Controllers
{
    public class HomeController : Controller
    {
        IStudentRepository _studentRepository;
        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {

            return View(_studentRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            _studentRepository.Add(student);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View(_studentRepository.GetAll());
            
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _studentRepository.Delete(student.Id);

            return RedirectToAction("Delete", "Home");
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View(_studentRepository.GetAll());

        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            _studentRepository.Update(student);

            return RedirectToAction("Index", "Home");
        }


    }
}
