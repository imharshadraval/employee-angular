using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace employee_angular
{
    public class EmployeeSalary
    {
        #region Properties
        public decimal EmpSal_Id { get; set; }
        public decimal EmpSal_Employee { get; set; }
        public string EmpSal_EmployeeName { get; set; }
        public decimal EmpSal_Salary { get; set; }
        public DateTime EmpSal_StartDate { get; set; }
        public DateTime EmpSal_EndDate { get; set; }
        #endregion

        #region Methods
        public static decimal Add(EmployeeSalary obj)
        {
            decimal Id = 0;
            string cmdText = "AddEmployeeSalary_sp";
            SqlConnection con = new SqlConnection(CommonConstant.CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmpSal_Employee", obj.EmpSal_Employee);
            cmd.Parameters.AddWithValue("EmpSal_Salary", obj.EmpSal_Salary);
            cmd.Parameters.AddWithValue("EmpSal_StartDate", obj.EmpSal_StartDate);
            cmd.Parameters.AddWithValue("EmpSal_EndDate", obj.EmpSal_EndDate);
            con.Open();
            Id = Convert.ToDecimal(cmd.ExecuteScalar());
            con.Close();
            return Id;
        }

        public static List<EmployeeSalary> FindByEmployee(decimal Id)
        {
            List<EmployeeSalary> list = new List<EmployeeSalary>();
            string cmdText = "FindEmployeeSalaryByEmployee_sp";
            SqlConnection con = new SqlConnection(CommonConstant.CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmpSal_Employee", Id);
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                EmployeeSalary obj = new EmployeeSalary();
                obj.EmpSal_Id = Convert.ToDecimal(dr.GetValue(dr.GetOrdinal("EmpSal_Id")));
                obj.EmpSal_Employee = Convert.ToDecimal(dr.GetValue(dr.GetOrdinal("EmpSal_Employee")));
                obj.EmpSal_EmployeeName = Convert.ToString(dr.GetValue(dr.GetOrdinal("EmpSal_EmployeeName")));
                obj.EmpSal_Salary = Convert.ToDecimal(dr.GetValue(dr.GetOrdinal("EmpSal_Salary")));
                obj.EmpSal_StartDate = Convert.ToDateTime(dr.GetValue(dr.GetOrdinal("EmpSal_StartDate")));
                obj.EmpSal_EndDate = Convert.ToDateTime(dr.GetValue(dr.GetOrdinal("EmpSal_EndDate")));
                list.Add(obj);
            }
            if (!dr.IsClosed)
                dr.Close();
            con.Close();
            return list;
        }

        public static List<EmployeeSalary> List()
        {
            List<EmployeeSalary> list = new List<EmployeeSalary>();
            string cmdText = "ListEmployeeSalary_sp";
            SqlConnection con = new SqlConnection(CommonConstant.CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                EmployeeSalary obj = new EmployeeSalary();
                obj.EmpSal_Id = Convert.ToDecimal(dr.GetValue(dr.GetOrdinal("EmpSal_Id")));
                obj.EmpSal_Employee = Convert.ToDecimal(dr.GetValue(dr.GetOrdinal("EmpSal_Employee")));
                obj.EmpSal_EmployeeName = Convert.ToString(dr.GetValue(dr.GetOrdinal("EmpSal_EmployeeName")));
                obj.EmpSal_Salary = Convert.ToDecimal(dr.GetValue(dr.GetOrdinal("EmpSal_Salary")));
                obj.EmpSal_StartDate = Convert.ToDateTime(dr.GetValue(dr.GetOrdinal("EmpSal_StartDate")));
                obj.EmpSal_EndDate = Convert.ToDateTime(dr.GetValue(dr.GetOrdinal("EmpSal_EndDate")));
                list.Add(obj);
            }
            if (!dr.IsClosed)
                dr.Close();
            con.Close();
            return list;
        }

        public static EmployeeSalary Find(decimal Id)
        {
            EmployeeSalary obj = null;
            string cmdText = "FindEmployeeSalary_sp";
            SqlConnection con = new SqlConnection(CommonConstant.CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmpSal_Id", Id);
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj = new EmployeeSalary();
                obj.EmpSal_Id = Convert.ToDecimal(dr.GetValue(dr.GetOrdinal("EmpSal_Id")));
                obj.EmpSal_Employee = Convert.ToDecimal(dr.GetValue(dr.GetOrdinal("EmpSal_Employee")));
                obj.EmpSal_EmployeeName = Convert.ToString(dr.GetValue(dr.GetOrdinal("EmpSal_EmployeeName")));
                obj.EmpSal_Salary = Convert.ToDecimal(dr.GetValue(dr.GetOrdinal("EmpSal_Salary")));
                obj.EmpSal_StartDate = Convert.ToDateTime(dr.GetValue(dr.GetOrdinal("EmpSal_StartDate")));
                obj.EmpSal_EndDate = Convert.ToDateTime(dr.GetValue(dr.GetOrdinal("EmpSal_EndDate")));
            }
            if (!dr.IsClosed)
                dr.Close();
            con.Close();
            return obj;
        }

        public static int Update(EmployeeSalary obj)
        {
            int count = 0;
            string cmdText = "UpdateEmployeeSalary_sp";
            SqlConnection con = new SqlConnection(CommonConstant.CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmpSal_Id", obj.EmpSal_Id);
            cmd.Parameters.AddWithValue("EmpSal_Employee", obj.EmpSal_Employee);
            cmd.Parameters.AddWithValue("EmpSal_Salary", obj.EmpSal_Salary);
            cmd.Parameters.AddWithValue("EmpSal_StartDate", obj.EmpSal_StartDate);
            cmd.Parameters.AddWithValue("EmpSal_EndDate", obj.EmpSal_EndDate);
            con.Open();
            count = cmd.ExecuteNonQuery();
            con.Close();
            return count;
        }

        public static int Delete(decimal Id)
        {
            int count = 0;
            string cmdText = "DeleteEmployeeSalary_sp";
            SqlConnection con = new SqlConnection(CommonConstant.CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmpSal_Id", Id);
            con.Open();
            count = cmd.ExecuteNonQuery();
            con.Close();
            return count;
        }

        public static int DeleteByEmployee(decimal Id)
        {
            int count = 0;
            string cmdText = "DeleteEmployeeSalaryByEmployee_sp";
            SqlConnection con = new SqlConnection(CommonConstant.CONNECTIONSTRING);
            SqlCommand cmd = new SqlCommand(cmdText, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("EmpSal_Employee", Id);
            con.Open();
            count = cmd.ExecuteNonQuery();
            con.Close();
            return count;
        }
        #endregion
    }
}