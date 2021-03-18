using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employee_angular.Controllers
{
    [ApiController]
    public class EmployeeSalaryController : Controller
    {
        [HttpGet]
        [Route("EmployeeSalary")]
        public IEnumerable<EmployeeSalary> Index()
        {
            return EmployeeSalary.List();
        }

        [HttpPost]
        [Route("EmployeeSalary/Create")]
        public decimal Create(EmployeeSalary employee)
        {
            return EmployeeSalary.Add(employee);
        }

        [HttpGet]
        [Route("EmployeeSalary/Find/{id}")]
        public EmployeeSalary Find(decimal id)
        {
            return EmployeeSalary.Find(id);
        }

        [HttpGet]
        [Route("EmployeeSalary/FindByEmployee/{id}")]
        public IEnumerable<EmployeeSalary> FindByEmployee(decimal id)
        {
            return EmployeeSalary.FindByEmployee(id);
        }

        [HttpPut]
        [Route("EmployeeSalary/Edit")]
        public int Edit(EmployeeSalary employee)
        {
            return EmployeeSalary.Update(employee);
        }

        [HttpDelete]
        [Route("EmployeeSalary/Delete/{id}")]
        public int Delete(decimal id)
        {
            return EmployeeSalary.Delete(id);
        }

        [HttpDelete]
        [Route("EmployeeSalary/DeleteByEmployee/{id}")]
        public int DeleteByEmployee(decimal id)
        {
            return EmployeeSalary.DeleteByEmployee(id);
        }
    }
}
