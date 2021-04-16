import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';  

@Injectable({
  providedIn: 'root'
})
export class AppService {
  readonly rootURL = 'http://localhost:1168/API';
  constructor(private http: HttpClient) { }
  
  httpOptions = {  
    headers: new HttpHeaders({  
      'Content-Type': 'application/json'  
    })  
  }    
  buscarData(){  
    return this.http.get(this.rootURL + '/Produto/BuscarTodos'); 
  }        
  cadastrarData(formData){  
    return this.http.post(this.rootURL + '/Produto/Cadastrar',formData);  
  }  
  // postData(id,formData){  
  //   return this.http.put(this.rootURL + '/Produto/'+id,formData);  
  // }  
  exluirData(id){  
    return this.http.delete(this.rootURL + '/Produto/Excluir'+id);  
  }  
}
