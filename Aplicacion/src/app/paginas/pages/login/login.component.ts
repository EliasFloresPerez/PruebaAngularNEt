import { Component } from '@angular/core';
import { ApiServiceService } from 'src/app/api-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  //Constructor de service
  constructor(private apiserviceservice: ApiServiceService) {}

  onSubmit() {
    
    
    const data = {
      email: this.username,
      password: this.password
    };

    this.apiserviceservice.PostLogin(data).subscribe((response: any) => {
      
      
      if (response.status) {
        console.log('Login correcto');
        localStorage.setItem('token', response.token);

        //Ademas de guardar los datos de la persona

        localStorage.setItem('nombre', response.usuario.nombre);
        localStorage.setItem('email', response.usuario.email);


      } else {
        console.log('Login incorrecto');
      }
    });
    
  }
}
