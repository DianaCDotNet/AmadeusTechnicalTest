import { Component, inject, Input, numberAttribute, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Airlinestruct } from '../../interfaces/Airlinestruct';
import { ApiService } from '../../services/api.service';
import { FormAirlineComponent } from '../../form-airline/form-airline.component';

@Component({
  selector: 'app-edit-airline',
  standalone: true,
  imports: [FormAirlineComponent],
  templateUrl: './edit-airline.component.html',
  styleUrl: './edit-airline.component.css'
})
export class EditAirlineComponent implements OnInit {
  ngOnInit(): void {
    this.apiServices.getAirlineId(this.id).subscribe(obj => {
      this.airlinesList = obj;
    });
  }

  @Input({ transform: numberAttribute })
  id!: number;


  private apiServices = inject(ApiService);
  public airlinesList?: Airlinestruct;
  router = inject(Router)


  public save(airlines: Airlinestruct) {
    this.apiServices.updateAirline(this.id, airlines).subscribe(() => {
      this.router.navigate(["/Airline"]);
    });

  }
}
