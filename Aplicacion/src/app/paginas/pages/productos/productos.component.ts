import { Component } from '@angular/core';
import { ApiServiceService } from 'src/app/api-service.service';



@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent {

  //Constructor de service
  constructor(private apiserviceservice: ApiServiceService) {}

  //Recoger los productos
  productos: any = [];


  
  ngOnInit(): void {
    this.apiserviceservice.GetProductos().subscribe((response: any) => {
      console.log('Response:', response);
      this.productos = response;
    });



  }

}
