import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { PaginasRoutingModule } from './paginas-routing.module';
import { LoginComponent } from './pages/login/login.component';
import { ProductosComponent } from './pages/productos/productos.component';
import { SidebarComponent } from './pages/sidebar/sidebar.component';


@NgModule({
  declarations: [
    LoginComponent,
    ProductosComponent,
    SidebarComponent
  ],
  imports: [
    CommonModule,
    PaginasRoutingModule,
    FormsModule
  ]
})
export class PaginasModule { }
