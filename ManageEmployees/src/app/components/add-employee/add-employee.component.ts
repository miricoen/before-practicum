import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';

import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { RoleForEmployee } from '../../models/roleForEmployee.model';
import { TypeOfRole } from '../../models/typeOfRole.model';
import { TypeOfRolesService } from '../../services/type-of-roles.service';
import { Employee } from '../../models/employee.model';
import { EmployeeToPOst } from '../../models/employeeToPost.model';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [HttpClientModule, CommonModule, ReactiveFormsModule],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.scss',
})
export class AddEmployeeComponent implements OnInit {
  // errorMessage!: string;
  // successMessage!: string;
  // roleToAdd!: RoleForEmployee;
  // addEmployeeForm!: FormGroup;
  rolesArray: RoleForEmployee[] = [];
  typeOfRoles: TypeOfRole[] = [];
  // rolesFormArray!: FormArray;
  employeeFinal: EmployeeToPOst = new EmployeeToPOst();

  constructor(
    private _formBuilder: FormBuilder,
    public _typeOfRolesService: TypeOfRolesService
  ) {}

  ngOnInit(): void {
    this._typeOfRolesService.getRoles().subscribe((roles: TypeOfRole[]) => {
      this.typeOfRoles = roles;
      console.log('cpmponent', this.typeOfRoles);
    });

    // // הוספת פרטי העבודה למערך בסופו של הפורם
  }

  addEmployeeForm = this._formBuilder.group({
    firstName: new FormControl('', [
      Validators.required,
      Validators.minLength(3),
    ]),
    lastName: new FormControl('', [
      Validators.required,
      Validators.minLength(3),
    ]),
    isMale: new FormControl('true'), // ברירת מחדל - זכר
    startDate: new FormControl(new Date()), // תאריך התחלת עבודה
    bornDate: new FormControl(new Date()), // תאריך לידה

    roles: this._formBuilder.array([
      this._formBuilder.group({
        typeOfRoleId: new FormControl('', Validators.required),
        isManegemene: new FormControl('true'),
        DateOfEntryIntoWork: new FormControl(new Date()),
      }),
    ]),
  });
  rolesFormArray = this.addEmployeeForm.get('roles') as FormArray;
  // פונקציה להוספת פרטי העבודה
  addRole() {
    this.rolesFormArray = this.addEmployeeForm.get('roles') as FormArray;
    this.rolesFormArray.push(
      this._formBuilder.group({
        typeOfRoleId: new FormControl('', Validators.required),
        isManagement: new FormControl('true'),
        DateOfEntryIntoWork: new FormControl(new Date()),
      })
    );
  }

  // פונקציה למחיקת פרטי העבודה האחרונים
  removeRole(index: number) {
    this.rolesFormArray = this.addEmployeeForm.get('roles') as FormArray;
    this.rolesFormArray.removeAt(index);
  }

  onSubmit(): void {
    // this.employeeFinal.firstName = this.addEmployeeForm.get('firstName')!.value;
    // this.employeeFinal.lastName = this.addEmployeeForm.get('lastName')!.value;
    // this.employeeFinal.startDate = this.addEmployeeForm.get('startDate')!.value;
    // this.employeeFinal.bornDate = this.addEmployeeForm.get('bornDate')!.value;
    // this.employeeFinal.roles = this.addEmployeeForm.get('roles')!.value;
    // console.log(this.employeeFinal);
    console.log(
      'addEmployeeForm.value',
      this.addEmployeeForm.get('roles')!.value
    );
    // this.addEmployeeForm.at(itemIndex) as FormGroup).get('subItems') as FormArray;
  }
}
