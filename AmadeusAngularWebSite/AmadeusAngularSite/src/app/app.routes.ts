import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { AirlineComponent } from './pages/airline/airline.component';
import { AddAirlineComponent } from './pages/add-airline/add-airline.component';
import { EditAirlineComponent } from './pages/edit-airline/edit-airline.component';
import { RegistrerComponent } from './pages/registrer/registrer.component';

export const routes: Routes = [
    {path:"",component:LoginComponent},
    {path:"Airline",component:AirlineComponent},
    {path:"add-airline", component: AddAirlineComponent},
    {path:"edit-airline", component: EditAirlineComponent},
    {path:"register", component: RegistrerComponent},
    {path:"edit-airline/:id", component: EditAirlineComponent }
];
