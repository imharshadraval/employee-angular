using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace employee_angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(Employee.List(2));
        }

        public ActionResult Create()
        {
            ViewData["Department"] = CommonConstant.BindDepartment();
            ViewData["Status"] = CommonConstant.BindStatus();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee.Add(obj);
                    ViewBag.Message = "Employee Added Successfully";
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Edit(decimal id)
        {
            ViewData["Department"] = CommonConstant.BindDepartment();
            ViewData["Status"] = CommonConstant.BindStatus();
            Employee obj = Employee.Find(id);
            if (obj != null)
                return View(obj);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(decimal id, Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee obj = Employee.Find(id);
                    if (obj != null)
                    {
                        obj = employee;
                        Employee.Update(obj);
                        ViewBag.Message = "Employee Updated Successfully";
                    }
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Delete(decimal id)
        {
            try
            {
                Employee.Delete(id);
                EmployeeSalary.DeleteByEmployee(id);
                EmployeeDocument.DeleteByEmployee(id);
                ViewBag.Message = "Employee Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return Employee.List(2).ToArray();
        }
    }
}
