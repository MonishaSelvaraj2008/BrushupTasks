import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

interface ColumnVisibility {
  [key: string]: boolean;
}

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent {
  public showColumns: ColumnVisibility = {
    empId: true,
    empName: true,
    designation: true,
    location: true,
    address: true,
    salary: true
  };


  public employeeDetails = [
    { empId: 104, empName: 'Monisha', designation: 'Developer', location: 'Dindigul', address: 'XXX City', salary: 30000 },
    { empId: 105, empName: 'Anusha', designation: 'Tester', location: 'Palani', address: 'YYY City', salary: 40000 },
    { empId: 106, empName: 'Abhishek', designation: 'Developer', location: 'Hyderabad', address: 'ZZZ City', salary: 40000 },
    { empId: 107, empName: 'Sandhiya', designation: 'Tech-Support', location: 'Bengaluru', address: 'XXX, YYY', salary: 20000 },
    { empId: 108, empName: 'Siva', designation: 'BA', location: 'Chennai', address: 'YYY, ZZZ', salary: 30000 },
    { empId: 109, empName: 'Rajesh', designation: 'Developer', location: 'Dindigul', address: 'XXX City', salary: 150000 },
    { empId: 110, empName: 'Solomon', designation: 'Tester', location: 'KVP', address: 'XXX City', salary: 120000 },
    { empId: 111, empName: 'Priya', designation: 'Developer', location: 'New Delhi', address: 'XXX City', salary: 60000 },
    { empId: 112, empName: 'Kripashini', designation: 'QA', location: 'Haryana', address: 'XXX City', salary: 29000 }
  ];

  public toggleColumn(column: string) {
    this.showColumns[column] = !this.showColumns[column];
  }

}
