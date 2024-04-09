import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee.model';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormArray,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TypeOfRole } from '../../models/typeOfRole.model';
import { TypeOfRolesService } from '../../services/type-of-roles.service';

@Component({
  selector: 'app-edit-employee',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './edit2.component.html',
  styleUrl: './edit2.component.scss',
})
export class EditEmployeeComponent implements OnInit {
  editEmployeeForm!: FormGroup;
  currentEmployee!: Employee;
  typeOfRoles: TypeOfRole[] = [];
  fname!: string;
  rolesFormArray!: FormArray<any>;
  constructor(
    private _route: ActivatedRoute,
    private _employeeService: EmployeeService,
    private _formBuilder: FormBuilder,
    public _typeOfRolesService: TypeOfRolesService
  ) {
    this._route.params.subscribe(async (param) => {
      const fetchedEmpId = param['id'];
      console.log(fetchedEmpId);
      this._employeeService.getEmpById(fetchedEmpId).subscribe((emp: Employee) => {
        if (emp) {
          this.currentEmployee = emp;
          console.log(this.currentEmployee);
    
          // כאן ייצר את הטופס רק כאשר הנתונים זמינים
          this.editEmployeeForm = this._formBuilder.group({
            firstName: new FormControl(this.currentEmployee.firstName, [
              Validators.required,
              Validators.minLength(3),
            ]),
          });
        }
      });
    
      this._typeOfRolesService.getRoles().subscribe((roles: TypeOfRole[]) => {
        this.typeOfRoles = roles;
        console.log('cpmponent', this.typeOfRoles);
      });
    });
    
    // this.editEmployeeForm = this._formBuilder.group({
    //   firstName: new FormControl(this.currentEmployee.firstName, [
    //     Validators.required,
    //     Validators.minLength(3),
    //   ]),
    //   lastName: new FormControl('', [
    //     Validators.required,
    //     Validators.minLength(3),
    //   ]),
    //   isMale: new FormControl(true), // ברירת מחדל - זכר
    //   bornDate: new FormControl(new Date()), // תאריך לידה
    //   startDate: new FormControl(new Date()), // תאריך התחלת עבודה
    //   roles: this._formBuilder.array([
    //     this._formBuilder.group({
    //       typesOfRolesId: new FormControl(0, [
    //         Validators.required,
    //         Validators.pattern(/^-?\d*\.?\d*$/),
    //       ]),
    //       isManagment: new FormControl(true),
    //       dateOfEntryIntoWork: new FormControl(new Date()),
    //     }),
    //   ]),
    // });
    // this. rolesFormArray = this.editEmployeeForm.get('roles') as FormArray;
    // this.fname = this.currentEmployee.firstName;

  }

  ngOnInit(): void {
    // this._route.params.subscribe(async (param) => {
    //   const fetchedEmpId = param['id'];
    //   console.log(fetchedEmpId);
    //   this._employeeService
    //     .getEmpById(fetchedEmpId)
    //     .subscribe((emp: Employee) => {
    //       if (emp) {
    //         this.currentEmployee = emp;
    //         console.log(this.currentEmployee);
    //         // this.fname = this.currentEmployee.firstName;
    //       }
    //     });
    // });
    // this._typeOfRolesService.getRoles().subscribe((roles: TypeOfRole[]) => {
    //   this.typeOfRoles = roles;
    //   console.log('cpmponent', this.typeOfRoles);
    // });

    // console.log('this.currentEmployee', this.currentEmployee);
    // this.editEmployeeForm = this._formBuilder.group({
    //   firstName: new FormControl(this.fname, [
    //     Validators.required,
    //     Validators.minLength(3),
    //   ]),
    // });
  }

  public initForm(): void {
    this.currentEmployee.roles.forEach((role) => {
      this.addRoleWithParams(
        role.typesOfRolesId!,
        role.isManagment!,
        role.dateOfEntryIntoWork!
      );
    });
  }

  addRoleWithParams(arg0: number, arg1: boolean, arg2: Date) {
    throw new Error('Method not implemented.');
  }

  addRole() {
    this.rolesFormArray = this.editEmployeeForm.get('roles') as FormArray;
    this.rolesFormArray.push(
      this._formBuilder.group({
        typesOfRolesId: new FormControl(0, [
          Validators.required,
          Validators.pattern(/^-?\d*\.?\d*$/),
        ]),
        isManagment: new FormControl(true),
        dateOfEntryIntoWork: new FormControl(new Date()),
      })
    );
  }

  removeRole(index: number): void {
    this.rolesFormArray.removeAt(index);
  }
  onSubmit() {
    // this.currentEmployee.firstName =
    //   this.editEmployeeForm.get('firstName')!.value!;
    // this.currentEmployee.lastName =
    //   this.editEmployeeForm.get('lastName')!.value!;
    // this.currentEmployee.startDate = new Date(
    //   this.editEmployeeForm.get('startDate')!.value!
    // );
    // this.currentEmployee.bornDate = new Date(
    //   this.editEmployeeForm.get('bornDate')!.value!
    // );
    // this.currentEmployee.isMale =
    //   this.editEmployeeForm.get('isMale')!.value === true;
    // this.currentEmployee.roles = this.editEmployeeForm.get('roles')!.value;
    // const transformedData = this.currentEmployee.roles.map((item) => ({
    //   typesOfRolesId:
    //     item.typesOfRolesId != null ? Number(item.typesOfRolesId) : 0,
    //   isManagment: item.isManagment === true,
    //   dateOfEntryIntoWork:
    //     item.dateOfEntryIntoWork !== null
    //       ? new Date(item.dateOfEntryIntoWork)
    //       : null,
    // }));
    // this.currentEmployee.roles = transformedData;
    // this.currentEmployee.status = true;
  }
}
