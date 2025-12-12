import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ApiAmadeusService {
    private http = inject(HttpClient);
  private URLbase= environment.apiURL + '/airlines'

  public getAirlines()
  {
    return this.http.get<any>(this.URLbase);
  }

}
