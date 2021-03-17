using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace employee_angular
{
    public class CommonConstant
    {
        //public static string CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        //public static string CONNECTIONSTRING = @"Data Source=HARSHAD-LAPTOP\SQLSERVER;Initial Catalog=Employee;User Id=sa; Password=Harshad@1992;";
        public static string CONNECTIONSTRING = Startup._configuration.GetConnectionString("DefaultConnection");

        public static List<SelectListItem> BindDepartment()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            try
            {
                SelectListItem item = new SelectListItem();
                item.Value = "1";
                item.Text = "IT";
                listItems.Add(item);

                item = new SelectListItem();
                item.Value = "2";
                item.Text = "Marketing";
                listItems.Add(item);

                item = new SelectListItem();
                item.Value = "3";
                item.Text = "Accounting";
                listItems.Add(item);

                item = new SelectListItem();
                item.Value = "4";
                item.Text = "Support";
                listItems.Add(item);

                item = new SelectListItem();
                item.Value = "5";
                item.Text = "Production";
                listItems.Add(item);

                item = new SelectListItem();
                item.Value = "6";
                item.Text = "R&D";
                listItems.Add(item);

                item = new SelectListItem();
                item.Value = "7";
                item.Text = "HR";
                listItems.Add(item);
            }
            catch (Exception)
            {
                throw;
            }

            return listItems;
        }

        public static List<SelectListItem> BindStatus()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            try
            {
                SelectListItem item = new SelectListItem();
                item.Value = "1";
                item.Text = "Active";
                listItems.Add(item);

                item = new SelectListItem();
                item.Value = "0";
                item.Text = "Inactive";
                listItems.Add(item);
            }
            catch (Exception)
            {
                throw;
            }

            return listItems;
        }

        public static List<SelectListItem> BindDocumentType()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            try
            {
                SelectListItem item = new SelectListItem();
                item.Value = "1";
                item.Text = "Photograph";
                listItems.Add(item);

                item = new SelectListItem();
                item.Value = "2";
                item.Text = "Signature";
                listItems.Add(item);

                item = new SelectListItem();
                item.Value = "3";
                item.Text = "PAN Card";
                listItems.Add(item);

                item = new SelectListItem();
                item.Value = "4";
                item.Text = "Aadhar Card";
                listItems.Add(item);

                item = new SelectListItem();
                item.Value = "5";
                item.Text = "Voter Id";
                listItems.Add(item);

                item = new SelectListItem();
                item.Value = "6";
                item.Text = "Driving Licence";
                listItems.Add(item);

                item = new SelectListItem();
                item.Value = "7";
                item.Text = "Passport";
                listItems.Add(item);
            }
            catch (Exception)
            {
                throw;
            }

            return listItems;
        }
    }
}
