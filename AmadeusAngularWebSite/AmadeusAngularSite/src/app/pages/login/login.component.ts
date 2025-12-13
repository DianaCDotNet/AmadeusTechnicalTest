import { Component, inject } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Router, RouterModule } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginApi } from '../../interfaces/LoginApi';
import { MatCardModule } from '@angular/material/card';
import { MatFormField } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    MatCardModule,
    MatFormField,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    RouterModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  private apiServices = inject(ApiService);
  private router = inject(Router);
  public formBuild = inject(FormBuilder);

  public formLogin: FormGroup = this.formBuild.group({
    email: ['admin@as.com', Validators.required],   // se quema valor por defecto
    password: ['-Admin-123.', Validators.required]
  });

  star() {

    if (this.formLogin.invalid) {
      alert("Credentials error ");
      return;
    }

    const objeto: LoginApi = {
      email: this.formLogin.value.email,
      password: this.formLogin.value.password,
      twoFactorCode: '',
      twoFactorRecoveryCode: ''
    }

    this.apiServices.LogIn(objeto).subscribe(
      {
        next: (data) => {
          if (data.tokenType) {
            localStorage.setItem("token", data.accessToken)
            this.router.navigate(['Airline']);
            //console.log(data);
          }
          else {
            alert("Credentials error ");
          }
        },
        error: (error) => {
          console.log(error.message);
          alert("Credentials error ");
        }
      });
  }

}
