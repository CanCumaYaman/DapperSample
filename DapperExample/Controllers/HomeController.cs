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

        
    }
}
