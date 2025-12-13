import { Component, inject } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormField } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { User } from '../../interfaces/User';

@Component({
  selector: 'app-registrer',
  standalone: true,
  imports: [
    MatCardModule,
    MatFormField,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    RouterModule],
  templateUrl: './registrer.component.html',
  styleUrl: './registrer.component.css'
})
export class RegistrerComponent {
  private apiServices = inject(ApiService);
  private router = inject(Router);
  public formBuild = inject(FormBuilder);


  public formRegistrer: FormGroup = this.formBuild.group({
    email: ['', Validators.required],
    password: ['', Validators.required]
  });

  register() {
    if (this.formRegistrer.invalid) {
      alert("Credentials error ");
      return;
    }
    const objeto: User = {
      email: this.formRegistrer.value.email,
      password: this.formRegistrer.value.password
    }
    this.apiServices.Regsiter(objeto).subscribe(
      {
        next: (data) => {
          console.log(data);
          if (data !=null) {
            this.router.navigate(['']);
            //console.log(data);
          }
          else {
            alert("Error ");
          }
        },
        error: (error) => {
          console.log(error.message);
          alert("Internal Error ");
        }
      })

  }

}
