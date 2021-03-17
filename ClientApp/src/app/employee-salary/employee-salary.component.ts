import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employee-salary',
  templateUrl: './employee-salary.component.html'
})
export class EmployeeSalaryComponent {
  public employeeSalaries: EmployeeSalary[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<EmployeeSalary[]>(baseUrl + 'employeesalary').subscribe(result => {
      this.employeeSalaries = result;
    }, error => console.error(error));
  }
}

interface EmployeeSalary {
  EmpSal_Id: number;
  EmpSal_Employee: number;
  EmpSal_EmployeeName: string;
  EmpSal_Salary: number;
  EmpSal_StartDate: string;
  EmpSal_EndDate: string;
}
