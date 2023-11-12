import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { ProductosComponent } from './pages/productos/productos.component';

const routes: Routes = [

  {
    path: '',
    children: [
      {path: 'login', component: LoginComponent},
      {path: 'productos', component: ProductosComponent},
      
      {path: '**', redirectTo: 'login'},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PaginasRoutingModule { }
