import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { AirlineComponent } from './pages/airline/airline';

export const routes: Routes = [
    {path:"",component:Login},
    {path:"Airline",component:AirlineComponent}
];
