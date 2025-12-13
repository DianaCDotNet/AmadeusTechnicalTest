import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldControl, MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router, RouterModule } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { Airlinestruct } from '../../interfaces/Airlinestruct';
import { EventEmitter, Output } from '@angular/core';
import { FormAirlineComponent } from '../../form-airline/form-airline.component';

@Component({
  selector: 'app-add-airline',
  standalone: true,
  imports: [MatButtonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    RouterModule,
  FormAirlineComponent],
  templateUrl: './add-airline.component.html',
  styleUrl: './add-airline.component.css'
})
export class AddAirlineComponent {
  private readonly formBuilder = inject(FormBuilder);
  private apiServices = inject(ApiService);
  router = inject(Router);


  public save(airlines:Airlinestruct) {
    this.apiServices.createAirline(airlines).subscribe(() => {
      this.router.navigate(["/Airline"]);
    });

  }
}
