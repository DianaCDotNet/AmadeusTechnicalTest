import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { Airlinestruct } from '../interfaces/Airlinestruct';
import { LoginApi } from '../interfaces/LoginApi';
import { Responseacces } from '../interfaces/Responseacces';
import { User } from '../interfaces/User';
import { ResponseUser } from '../interfaces/ResponseUser';
import { ResponseAirline } from '../interfaces/ResponseAirline';

@Injectable({
  providedIn: 'root'
})
export class ApiService {


  constructor() { }


  private http = inject(HttpClient);
  private URLbase = environment.apiURL + '/airlines';
  private URLLogin = environment.apiURL + '/identity/login';
  private URLRegister = environment.apiURL + '/identity/register';

  public getAirlinesList(): Observable<Airlinestruct[]> {
    return this.http.get<Airlinestruct[]>(this.URLbase);
  }

  public getAirlineId(id:number): Observable<Airlinestruct> {
    return this.http.get<Airlinestruct>(`${this.URLbase}/${id}`);
  }

  public LogIn(objeto: LoginApi): Observable<Responseacces> {
    return this.http.post<Responseacces>(this.URLLogin, objeto)
  }
  public Regsiter(objeto: User): Observable<ResponseUser> {
    return this.http.post<ResponseUser>(this.URLRegister, objeto)
  }

  /*   public createAirline(airline: iAirline): Observable<iAirline> {
      return this.http.post<iAirline>(this.URLbase, airline,{
       headers: new HttpHeaders({
      'Authorization':  `Bearer ${localStorage.getItem("token")}` })
     });
    } */

  public createAirline(airline: Airlinestruct) {
    console.log(airline);
    return this.http.post(this.URLbase, airline);
  }

  public deleteAirline(id: number): Observable<void> {
    return this.http.delete<void>(`${this.URLbase}/${id}`);
  }
  public updateAirline(id: number, airline: Airlinestruct): Observable<void> {
    return this.http.put<void>(`${this.URLbase}/${id}`, airline);
  }
}
