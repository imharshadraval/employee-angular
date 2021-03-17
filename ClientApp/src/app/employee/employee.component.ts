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
  emp_Name: string;
  emp_DOB: string;
  emp_DepartmentName: string;
  emp_Status: number;
  emp_Id: number;
}
