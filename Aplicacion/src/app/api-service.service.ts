import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders  } from '@angular/common/http'; // Importa el módulo HttpClient
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {
  private apiUrl = 'https://localhost:7095';

  constructor(private http: HttpClient) {}

  token: string = '';

  datos ={
    nombre: '',
    email: ''
  };

  


  PostLogin(data: any): Observable<any>{
    

    const httpOptions = {
      headers: new HttpHeaders({
        'Accept': '*/*',
      })
    };


    const url = this.apiUrl + '/api/Usuario/login';

    
    console.log('URL:', url, 'Data:', data);
    return this.http.post(url,data , httpOptions);

  }

  //Recoger los productos

  GetProductos(){
      const httpOptions = {
        headers: new HttpHeaders({
          'Accept': '*/*',
        })};

      const url = this.apiUrl + '/getProductos';

      return this.http.get(url, httpOptions);

    }
}
