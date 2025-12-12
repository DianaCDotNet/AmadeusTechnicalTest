import { Component, inject, OnInit } from '@angular/core';
import { ApiServices } from '../../services/api-services';
import { iAirline } from '../../interfaces/iAirline';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-airline',
  standalone: true,
  imports: [MatCardModule, MatTableModule],
  templateUrl: './airline.html',
  styleUrls: ['./airline.css']
})
export class AirlineComponent implements OnInit {
  private apiServices = inject(ApiServices);


  public dataSource = new MatTableDataSource<iAirline>();

  public displayedColumns: string[] = [
    'Id',
    'Name',
    'NumberFlightsPerDay',
    'OriginCountry',
    'ExternalIdentification',
    'AdditionalInformation'
  ];

  ngOnInit(): void {
    this.apiServices.getAirlinesList().subscribe({
      next: (data: iAirline[]) => {
        this.dataSource.data = data; 
        console.log(data);
      },
      error: (error) => {
        console.error(error.message);
      }
    });
  }
}
