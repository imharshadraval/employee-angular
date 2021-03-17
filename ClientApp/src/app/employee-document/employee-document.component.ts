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
  empDoc_Id: number;
  empDoc_Employee: number;
  empDoc_EmployeeName: string;
  empDoc_Type: number;
  empDoc_TypeName: string;
  empDoc_File: string;
  empDoc_Status: number;
}
