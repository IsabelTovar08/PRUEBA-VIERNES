import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Inject, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ApiService } from '../../../../services/api.service';
import { FormFormComponent } from '../../Form/form-form/form-form.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@Component({
  selector: 'app-reserva-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatButtonModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  templateUrl: './reserva-form.component.html',
  styleUrl: './reserva-form.component.css'
})
export class ReservaFormComponent {
  @Input() form: any;
  @Output() cerrar = new EventEmitter<boolean>();

  formForm!: FormGroup;
  isEditMode = false;
  clientes: any;
  vehiculos: any;
  estados: any;


  constructor(
    private fb: FormBuilder,
    private apiService: ApiService,
    public dialogRef: MatDialogRef<ReservaFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.form = data;
  }

  ngOnInit(): void {
    this.isEditMode = !!this.form;
    const now = new Date().toISOString();

    this.formForm = this.fb.group({
      id: [this.form?.id || 0],
      isDeleted: [false],
      clienteId: [this.form?.clienteId || '', Validators.required],
      pizzaId: [this.form?.pizzaId || '', Validators.required],
      estadoPedidoId: [this.form?.estadoPedidoId || '', Validators.required],
      cantidad: [this.form?.cantidad || 1, Validators.required],
      nombrePizza: '',
      nombreCliente: '',
      fecha: [null]
    });
    this.cargarClientes();
    this.cargarVehiculos();
    this.cargarEstados();


  }

  guardarform() {
    const reserva = this.formForm.value;

    if (this.isEditMode) {
      this.apiService.update('Pedido', reserva).subscribe(() => {
        console.log("Reserva actualizada");
        this.dialogRef.close('reload');
      });
    } else {
      this.apiService.Crear('Pedido', reserva).subscribe(() => {
        console.log("Reserva creada");
        this.dialogRef.close('reload');
      });
    }
  }

  cargarClientes() {
    this.apiService.ObtenerTodo('Cliente').subscribe((data: any) => {
      this.clientes = data;
    });
  }

  cargarVehiculos() {
    this.apiService.ObtenerTodo('Pizza').subscribe((data: any) => {
      this.vehiculos = data;
    });
  }

  cargarEstados() {
    this.apiService.ObtenerTodo('EstadoPedido').subscribe((data: any) => {
      this.estados = data;
    });
  }
}
