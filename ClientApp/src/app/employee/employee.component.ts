import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent {
  public employees: Employee[];
  url = 'https://localhost:44355/employee';

  constructor(private http: HttpClient) {
    http.get<Employee[]>(this.url).subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }

  //constructor(private http: HttpClient) {
  //  this.List();
  //}

  List(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.url);
  }

  Find(employeeId: string): Observable<Employee> {
    return this.http.get<Employee>(this.url + '/Find/' + employeeId);
  }

  Create(employee: Employee): Observable<Employee> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Employee>(this.url + '/Create/', employee, httpOptions);
  }

  Update(employee: Employee): Observable<Employee> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Employee>(this.url + '/Update/', employee, httpOptions);
  }

  Delete(employeeId: string): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<number>(this.url + '/Delete?Id=' + employeeId, httpOptions);
  }
}

interface Employee {
  emp_Name: string;
  emp_DOB: string;
  emp_DepartmentName: string;
  emp_Status: number;
  emp_Id: number;
}
