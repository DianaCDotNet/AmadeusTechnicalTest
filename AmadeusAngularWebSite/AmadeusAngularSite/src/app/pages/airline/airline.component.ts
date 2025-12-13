import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { Airlinestruct } from '../../interfaces/Airlinestruct';
import { MatButtonModule } from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-airline',
  standalone: true,
  imports: [
    MatButtonModule,
    RouterLink,
    MatTableModule, 
    
  ],
  templateUrl: './airline.component.html',
  styleUrl: './airline.component.css'
})
export class AirlineComponent {

  private router = inject(Router);
  private apiServices = inject(ApiService);
  public airlineList: Airlinestruct[] = [];
  public dataSource = new MatTableDataSource<Airlinestruct>();
  public displayedColumns: string[] = [
    'Id',
    'Name',
    'NumberFlightsPerDay',
    'OriginCountry',
    'ExternalIdentification',
    'AditionalInformation',
    'Actions'
  ];

  constructor() {
    this.load();

  }

  delete(id: number) {
    this.apiServices.deleteAirline(id).subscribe(
      {
        next: (data) => {
           this.load();
        },
        error: (error) => {
          console.log(error.message);
          alert("Permissions");
        }
      });
  }

  load() {
    this.apiServices.getAirlinesList().subscribe(
      {
        next: (data) => {
          console.log(data);
          this.airlineList = data;
          console.log(this.airlineList);

        },
        error: (error) => {
          console.log(error.message);
          alert("Internal error ");
        }
      });
  }
}
