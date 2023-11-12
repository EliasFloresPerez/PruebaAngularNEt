import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [

  {
    path: 'App',
    loadChildren: () => import('./paginas/paginas.module').then(m => m.PaginasModule)
  },
  {path: '**', redirectTo: 'App'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
