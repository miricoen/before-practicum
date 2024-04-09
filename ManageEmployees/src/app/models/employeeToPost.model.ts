import { RoleForEmployee } from './roleForEmployee.model';

export class EmployeeToPOst {
  firstName!: string;
  lastName!: string;
  startDate!: Date;
  bornDate!: Date;
  isMale!: boolean;
  roles!: RoleForEmployee[];
  status!: boolean;
}
