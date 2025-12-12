import { Component, inject, signal } from '@angular/core';

import { ApiAmadeusService } from './api-amadeus-service';

@Component({
  selector: 'app-root',
  standalone:true,
  imports: [],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('AmadeusAngularSite');
  apiAmadeusServices=inject(ApiAmadeusService);
  airlines:any[]=[];

  constructor()
  {
    this.apiAmadeusServices.getAirlines().subscribe(data=>{
      this.airlines = data;
      console.log(this.airlines);
    });
  }
}
