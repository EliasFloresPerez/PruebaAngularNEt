import { Component } from '@angular/core';
import { ApiServiceService } from 'src/app/api-service.service';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {

  iniciarSesion() {
    
    console.log('Iniciar Sesión');
  }


  //Sacamos el token guardado en el localStorage

  Registro = false;
  Datos:any = {};

  constructor(private apiserviceservice: ApiServiceService) {}

  isSidebarOpen = false;

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }

  
  ngOnInit(): void {
    this.apiserviceservice.token = localStorage.getItem('token') || '';
    this.apiserviceservice.datos.nombre = localStorage.getItem('nombre') || '';
    this.apiserviceservice.datos.email = localStorage.getItem('email') || '';


    if (this.apiserviceservice.token != '') {
      this.Registro = true;
      
      this.Datos = {
        nombre : this.apiserviceservice.datos.nombre,
        email : this.apiserviceservice.datos.email
      };
    }else{
      this.Registro = false;

    }
    
    
  }









}
