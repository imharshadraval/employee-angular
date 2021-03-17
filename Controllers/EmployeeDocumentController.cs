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
    [Route("[controller]")]
    public class EmployeeDocumentController : Controller
    {
        private IHostingEnvironment _env;
        public EmployeeDocumentController(IHostingEnvironment env)
        {
            _env = env;
        }

        public ActionResult Index()
        {
            return View(EmployeeDocument.List());
        }

        [HttpGet]
        public IEnumerable<EmployeeDocument> Get()
        {
            return EmployeeDocument.List().ToArray();
        }

        public ActionResult Create(decimal? id)
        {
            ViewData["Employee"] = Employee.ListEmployee(1);
            ViewData["DocType"] = CommonConstant.BindDocumentType();
            ViewData["Status"] = CommonConstant.BindStatus();
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
        public ActionResult Create(EmployeeDocument obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.EmpDoc_File != null)
                    {
                        string fileName = DateTime.Now.ToString("ddMMyyyyhhmmsstt") + "_" + Path.GetFileName(obj.EmpDoc_File);
                        fileName = Regex.Replace(fileName, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                        string filePath = Path.Combine("~/Uploads/Documents/", fileName);
                        obj.EmpDoc_File = "~/Uploads/Documents/" + fileName;
                    }
                    else
                    {
                        obj.EmpDoc_File = string.Empty;
                    }
                    EmployeeDocument.Add(obj);
                    ViewBag.Message = "Employee Document Added Successfully";
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
            ViewData["DocType"] = CommonConstant.BindDocumentType();
            ViewData["Status"] = CommonConstant.BindStatus();
            EmployeeDocument obj = EmployeeDocument.Find(id);
            if (obj != null)
                return View(obj);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(decimal id, EmployeeDocument employeeDocument)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeDocument obj = EmployeeDocument.Find(id);
                    if (obj != null)
                    {
                        obj = employeeDocument;
                        if (obj.EmpDoc_File != null)
                        {
                            var webRoot = _env.WebRootPath;
                            var oldfileName = System.IO.Path.Combine(webRoot, obj.EmpDoc_File);
                            string fileName = DateTime.Now.ToString("ddMMyyyyhhmmsstt") + "_" + Path.GetFileName(obj.EmpDoc_File);
                            fileName = Regex.Replace(fileName, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                            string path = Path.Combine(webRoot, fileName);
                            obj.EmpDoc_File = "~/Uploads/Documents/" + fileName;

                            if (System.IO.File.Exists(oldfileName))
                            {
                                System.IO.File.Delete(oldfileName);
                            }
                        }
                        EmployeeDocument.Update(obj);
                        ViewBag.Message = "Employee Document Updated Successfully";
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
                //EmployeeDocument.Delete(id);
                EmployeeDocument obj = EmployeeDocument.Find(id);
                if (obj != null)
                {
                    EmployeeDocument.Delete(obj.EmpDoc_Id);
                    string oldfileName = obj.EmpDoc_File;
                    if (System.IO.File.Exists(oldfileName))
                    {
                        System.IO.File.Delete(oldfileName);
                    }
                }
                ViewBag.Message = "Employee Document Deleted Successfully";
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
                //EmployeeDocument.DeleteByEmployee(id);
                List<EmployeeDocument> list = EmployeeDocument.FindByEmployee(id);
                foreach (EmployeeDocument obj in list)
                {
                    EmployeeDocument.Delete(obj.EmpDoc_Id);
                    string oldfileName = obj.EmpDoc_File;
                    if (System.IO.File.Exists(oldfileName))
                    {
                        System.IO.File.Delete(oldfileName);
                    }
                }
                ViewBag.Message = "Employee Document(s) Deleted Successfully";
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
            return View(EmployeeDocument.FindByEmployee(id));
        }
    }
}
