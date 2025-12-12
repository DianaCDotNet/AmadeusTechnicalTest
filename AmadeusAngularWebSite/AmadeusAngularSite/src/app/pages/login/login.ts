import { Component, inject } from '@angular/core';
import { ApiServices } from '../../services/api-services';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginApi } from '../../interfaces/LogiApi';
import { MatCardModule } from '@angular/material/card';
import { MatFormField } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-login',
  standalone:true,
  imports: [
    MatCardModule,
    MatFormField,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule
  ],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
 private apiServices =inject(ApiServices);
 private router = inject(Router);
 public formBuild= inject( FormBuilder);

public formLogin: FormGroup = this.formBuild.group({
  email: ['admin@as.com', Validators.required],   // valor inicial
  password: ['-Admin-123.', Validators.required]   // valor inicial
});

 star(){
  
    if(this.formLogin.invalid)   
    {
      alert("Credentials error "); 
      return;
    }

    const objeto:LoginApi ={
      email: this.formLogin.value.email,
      password: this.formLogin.value.password,
      twoFactorCode: '',
      twoFactorRecoveryCode: ''
    }

    this.apiServices.LogIn(objeto).subscribe(
      { 
        next:(data)=>{
           console.log(data);
          if(data.tokenType)
          {
            localStorage.setItem("token",data.accessToken)
            this.router.navigate(['Airline']);
          }
          else
          {
            alert("Credentials error ");
          }
        },
        error:(error) =>{
          console.log(error.message);
          alert("Credentials error ");
        }
      }
    )
  }
}
