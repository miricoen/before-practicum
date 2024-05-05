import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, Subject } from 'rxjs';
import { Employee } from '../models/employee.model';
import { EmployeeToPost } from '../models/employeeToPost.model';
@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private apiUrl = 'https://localhost:7149/api/Employees'; // כאן יש להכניס את כתובת ה-URL של השרת
  private employeesSubject = new Subject<Employee[]>(); // הוספת Subject
  public employees: Employee[] = [];

  constructor(private http: HttpClient) {
    this.fetchEmployees();
  }
  fetchEmployees() {
    this.getEmployees().subscribe(
      (employee: Employee[]) => {
        this.employeesSubject.next(employee); // הודע ל-subject כאשר הנתונים מוכנים
        this.employees = employee;
      },
      (error) => {
        console.error('Error fetching employees:', error);
      }
    );
  }
  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl);
  }
  getEmployeesSubject(): Observable<Employee[]> {
    return this.employeesSubject.asObservable(); // החזר את ה-subject כ- Observable
  }

  // delete(id: number) {
  //   var emp = this.getEmpById(id);
  //   if (emp) {
  //     emp.status = false;
  //   } else {
  //     console.error('Employee not found with ID:', id);
  //   }
  // }

  getEmpById(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/${id}`);
  }

  delete(id: number) {
    console.log('delete in service');
    console.log(`${this.apiUrl}/${id}`);
    // this.http.delete<void>(`${this.apiUrl}/${id}`);
    return this.http.delete<boolean>(`${this.apiUrl}/${id}`).subscribe(
      () => {
        console.log('Employee deleted successfully');
        // כאן תוכל להוסיף פעולות נוספות לאחר מחיקת העובד, כמו רענון רשימת העובדים או פעולות אחרות.
      },
      (error) => {
        console.error('Error deleting employee:', error);
      }
    );
  }

  // editEmployee(id: number, emp: Employee) {
  //   var empToPost: EmployeeToPost = {...emp};
  //   return this.http.put<boolean>(`${this.apiUrl}/${id}`, empToPost).subscribe(
  //     () => {
  //       console.log('Employee added successfully');
  //     },
  //     (error) => {
  //       console.error('Error adding employee:', error);
  //     }
  //   );
  // }
  editEmployee(id: number, emp: Employee): Observable<boolean> {
    var empToPost: EmployeeToPost = { ...emp };
    return this.http.put<boolean>(`${this.apiUrl}/${id}`, empToPost);
  }

 addEmployee(emp: EmployeeToPost): Observable<boolean> {
  console.log(emp);
    return this.http.post<boolean>(this.apiUrl, emp);
  }






}
