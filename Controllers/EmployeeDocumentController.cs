using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace employee_angular.Controllers
{
    [ApiController]
    public class EmployeeDocumentController : Controller
    {

        [HttpGet]
        [Route("EmployeeDocument")]
        public IEnumerable<EmployeeDocument> Index()
        {
            return EmployeeDocument.List();
        }

        [HttpPost]
        [Route("EmployeeDocument/Create")]
        public decimal Create(EmployeeDocument employee)
        {
            return EmployeeDocument.Add(employee);
        }

        [HttpGet]
        [Route("EmployeeDocument/Find/{id}")]
        public EmployeeDocument Find(decimal id)
        {
            return EmployeeDocument.Find(id);
        }

        [HttpGet]
        [Route("EmployeeDocument/FindByEmployee/{id}")]
        public IEnumerable<EmployeeDocument> FindByEmployee(decimal id)
        {
            return EmployeeDocument.FindByEmployee(id);
        }

        [HttpPut]
        [Route("EmployeeDocument/Edit")]
        public int Edit(EmployeeDocument employee)
        {
            return EmployeeDocument.Update(employee);
        }

        [HttpDelete]
        [Route("EmployeeDocument/Delete/{id}")]
        public int Delete(decimal id)
        {
            return EmployeeDocument.Delete(id);
        }

        [HttpDelete]
        [Route("EmployeeDocument/DeleteByEmployee/{id}")]
        public int DeleteByEmployee(decimal id)
        {
            return EmployeeDocument.DeleteByEmployee(id);
        }
    }
}
