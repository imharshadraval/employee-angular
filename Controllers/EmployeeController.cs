using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace employee_angular.Controllers
{
    [ApiController] 
    public class EmployeeController : Controller
    {
        [HttpGet]
        [Route("Employee")]
        public IEnumerable<Employee> Index()
        {
            return Employee.List(2);
        }

        [HttpPost]
        [Route("Employee/Create")]
        public decimal Create(Employee employee)
        {
            return Employee.Add(employee);
        }

        [HttpGet]
        [Route("Employee/Find/{id}")]
        public Employee Find(decimal id)
        {
            return Employee.Find(id);
        }

        [HttpPut]
        [Route("Employee/Edit")]
        public int Edit(Employee employee)
        {
            return Employee.Update(employee);
        }

        [HttpDelete]
        [Route("Employee/Delete/{id}")]
        public int Delete(decimal id)
        {
            return Employee.Delete(id);
        }
    }
}
