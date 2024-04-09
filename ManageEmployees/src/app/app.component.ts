import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmpTableComponent } from './components/emp-table/emp-table.component';
import { AddEmployeeComponent } from "./components/add-employee/add-employee.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [RouterOutlet, EmpTableComponent, AddEmployeeComponent]
})
export class AppComponent {
  title = 'ManageEmployees';
}
