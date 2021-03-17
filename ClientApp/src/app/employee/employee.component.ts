import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent {
  public employees: Employee[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Employee[]>(baseUrl + 'employee').subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }
}

interface Employee {
  Emp_Name: string;
  Emp_DOB: string;
  Emp_DepartmentName: string;
  Emp_Status: number;
  Emp_Id: number;
}
