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
  empSal_Id: number;
  empSal_Employee: number;
  empSal_EmployeeName: string;
  empSal_Salary: number;
  empSal_StartDate: string;
  empSal_EndDate: string;
}
