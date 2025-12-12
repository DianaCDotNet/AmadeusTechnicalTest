import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { iAirline } from '../interfaces/iAirline';

import { Responseacces } from '../interfaces/Responseacces';
import { LoginApi } from '../interfaces/LogiApi';


@Injectable({
  providedIn: 'root',
})
export class ApiServices {
  private http = inject(HttpClient);
  private URLbase= environment.apiURL + '/airlines'
  private URLLogin= environment.apiURL + '/identity/login'

  public getAirlines()
  {
    return this.http.get<iAirline>(this.URLbase);
  }

  public getAirlinesList():Observable<iAirline[]>
  {
    return this.http.get<iAirline[]>(this.URLbase);
  }

  public LogIn(objeto:LoginApi):Observable<Responseacces>{
    return this.http.post<Responseacces>(this.URLLogin,objeto)
  }
  
}
