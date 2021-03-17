import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employee-document',
  templateUrl: './employee-document.component.html'
})
export class EmployeeDocumentComponent {
  public employeeDocuments: EmployeeDocument[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<EmployeeDocument[]>(baseUrl + 'employeedocument').subscribe(result => {
      this.employeeDocuments = result;
    }, error => console.error(error));
  }
}

interface EmployeeDocument {
  EmpDoc_Id: number;
  EmpDoc_Employee: number;
  EmpDoc_EmployeeName: string;
  EmpDoc_Type: number;
  EmpDoc_TypeName: string;
  EmpDoc_File: string;
  EmpDoc_Status: number;
}
