import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee.model';
import { EmployeeService } from '../../services/employee.service';
import { Subscription } from 'rxjs';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTableDataSource } from '@angular/material/table';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-emp-table',
  standalone: true,
  imports: [CommonModule, MatFormFieldModule,MatTableModule],

  templateUrl: './emp-table.component.html',
  styleUrl: './emp-table.component.scss',
})
export class EmpTableComponent implements OnInit {
  dataSource = new MatTableDataSource<Employee>();
  private employeesSubscription!: Subscription;
  displayedColumns: string[] = [
    'firstName',
    'lastName',
    'tz',
    'startDate'
  ];


  constructor(public _employeeService: EmployeeService) {}
  ngOnInit(): void {
    this.employeesSubscription = this._employeeService
      .getEmployeesSubject()
      .subscribe(
        (employees: Employee[]) => {
          this.dataSource.data = employees; // מעדכן את המערך כאשר הנתונים מוכנים
          console.log(this.dataSource); // מדפיס את המערך רק כאשר הוא מעודכן עם הנתונים החדשים
        },
        (error) => {
          console.error('Error fetching employees:', error);
        }
      );
  }

  ngOnDestroy(): void {
    this.employeesSubscription.unsubscribe(); // בסיום הקומפוננטה, בטל את ההרשמה ל-Subject
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }


  delete(id: number) {
    console.log('delete in TS');
    this._employeeService.delete(id);
  }
}

// export class TableFilteringExample {
//   displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
//   dataSource = new MatTableDataSource(ELEMENT_DATA);

//   applyFilter(event: Event) {
//     const filterValue = (event.target as HTMLInputElement).value;
//     this.dataSource.filter = filterValue.trim().toLowerCase();
//   }
// }
