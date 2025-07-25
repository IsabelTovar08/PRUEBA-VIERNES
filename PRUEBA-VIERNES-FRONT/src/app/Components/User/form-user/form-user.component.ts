import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Inject, Input, Output } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormField } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ApiService } from '../../../../services/api.service';
import { FormModuleComponent } from '../../Module/form-module/form-module.component';

@Component({
  selector: 'app-form-user',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormField,
    MatInputModule,
    MatDialogModule,
    MatButtonModule,
    MatSelectModule
  ],
  templateUrl: './form-user.component.html',
  styleUrl: './form-user.component.css'
})
export class FormUserComponent {
  @Input() user: any;
  @Output() cerrar = new EventEmitter<boolean>();

  personas?: any[];

  userForm!: FormGroup;
  isEditMode = false;
  constructor(private fb: FormBuilder, private apiService: ApiService, public dialogRef: MatDialogRef<FormUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.user = data;

  }
  cargarpersonas() {
    this.apiService.ObtenerTodo('Pizza').subscribe(personas => {
      this.personas = personas;
    })
  }


  ngOnInit(): void {
    this.cargarpersonas();
    this.isEditMode = !!this.user;
    console.log(this.user)
    this.userForm = this.fb.group({
      id: [this.user?.id || 0],
      nombre: [this.user?.nombre || '', Validators.required],
      precio: [this.user?.precio || 0, Validators.required],
      isDeleted: [this.user?.isDeleted || false]


    });
  }

  guardarform() {
    console.log(this.userForm.value)
    if (this.isEditMode) {
      this.apiService.update('Pizza', this.userForm.value).subscribe(() => {
        console.log("update");
        this.dialogRef.close('reload');
      })
    }
    else {
      this.apiService.Crear('Pizza', this.userForm.value).subscribe(() => {
        console.log("creado");
        this.dialogRef.close('reload');
      })
    }
  }
}
