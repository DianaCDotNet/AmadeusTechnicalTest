import { Component, EventEmitter, inject, Input, input, OnInit, Output } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router, RouterModule } from '@angular/router';
import { ApiService } from '../services/api.service';
import { Airlinestruct } from '../interfaces/Airlinestruct';

@Component({
  selector: 'app-form-airline',
  standalone: true,
  imports: [MatButtonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    RouterModule],
  templateUrl: './form-airline.component.html',
  styleUrl: './form-airline.component.css'
})
export class FormAirlineComponent implements OnInit {
  ngOnInit(): void {
    if(this.airlinesList!==undefined)
    {
      this.form.patchValue(this.airlinesList);
    }
  }

  private readonly formBuilder = inject(FormBuilder);
  private apiServices = inject(ApiService);

  @Input({ required: true })
  title!: string;

  @Input()
  airlinesList!: Airlinestruct;

  @Output()
  postForm = new EventEmitter<Airlinestruct>();

  form = this.formBuilder.group({
    id: [0],
    name: [''],
    numberFlightsPerDay: [0],
    originCountry: [''],
    externalIdentification: [''],
    aditionalInformation: [''],
  })

  public save() {
    let airline = this.form.value as Airlinestruct;
    this.postForm.emit(airline);
  }
}
