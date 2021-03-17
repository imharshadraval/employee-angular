using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employee_angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeSalaryController : Controller
    {
        public ActionResult Index()
        {
            return View(EmployeeSalary.List());
        }

        [HttpGet]
        public IEnumerable<EmployeeSalary> Get()
        {
            return EmployeeSalary.List().ToArray();
        }

        public ActionResult Create(decimal? id)
        {
            ViewData["Employee"] = Employee.ListEmployee(1);
            if (id != null)
            {
                ViewData["CurrEmployee"] = id;
            }
            else
            {
                ViewData["CurrEmployee"] = string.Empty;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeSalary obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeSalary.Add(obj);
                    ViewBag.Message = "Employee Salary Added Successfully";
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
            ViewData["Employee"] = Employee.ListEmployee(1);
            EmployeeSalary obj = EmployeeSalary.Find(id);
            if (obj != null)
                return View(obj);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(decimal id, EmployeeSalary employeeSalary)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeSalary obj = EmployeeSalary.Find(id);
                    if (obj != null)
                    {
                        obj = employeeSalary;
                        EmployeeSalary.Update(obj);
                        ViewBag.Message = "Employee Salary Updated Successfully";
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
                EmployeeSalary.Delete(id);
                ViewBag.Message = "Employee Salary Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult DeleteByEmployee(decimal id)
        {
            try
            {
                EmployeeSalary.DeleteByEmployee(id);
                ViewBag.Message = "Employee Salary Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult List(decimal id)
        {
            ViewData["EmpId"] = id;
            return View(EmployeeSalary.FindByEmployee(id));
        }
    }
}
