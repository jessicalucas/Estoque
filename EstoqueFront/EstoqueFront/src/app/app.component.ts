import { Component } from '@angular/core';
import {AppService} from './app.service';  
import { FormGroup, FormControl,Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'EstoqueFront';
    constructor(private AppService: AppService) { }  
  data: any;  
  EstoqueForm: FormGroup;  
  submitted = false;   
  EventValue: any = "Salvar";    
  ngOnInit(): void {  
    this.getdata();    
    this.EstoqueForm = new FormGroup({  
      Id: new FormControl(null),  
      Nome: new FormControl("",[Validators.required]),        
      Quantidade: new FormControl("",[Validators.required]),  
      ValorUnitario:new FormControl("",[Validators.required]), 
    })    
  }  

  getdata() {  
    this.AppService.buscarData().subscribe((data: any[]) => {  
      this.data = data;  
    })  
  }  

  excluirData(id) {  
    this.AppService.exluirData(id).subscribe((data: any[]) => {  
      this.data = data;  
      this.getdata();  
    })  
  }  

  // Save() {   
  //   this.submitted = true;      
  //    if (this.CartaoForm.invalid) {  
  //           return;  
  //    }  
  //   this.AppService.postData(this.CartaoForm.value).subscribe((data: any[]) => {  
  //     this.data = data;  
  //     this.resetFrom();   
  //   })  
  // }  
  // Update() {   
  //   this.submitted = true;      
  //   if (this.CartaoForm.invalid) {  
  //    return;  
  //   }        
  //   this.AppService.putData(this.CartaoForm.value.PagamentoId,
  //            this.CartaoForm.value).subscribe((data: any[]) => {  
  //     this.data = data;  
  //     this.resetFrom();  
  //   })  
  // }  
  
  EditData(Data) {  
    this.EstoqueForm.controls["Id"].setValue(Data.Id);  
    this.EstoqueForm.controls["Nome"].setValue(Data.Nome);      
    this.EstoqueForm.controls["Quantidade"].setValue(Data.Quantidade);  
    this.EstoqueForm.controls["ValorUnitario"].setValue(Data.ValorUnitario);  
    this.EventValue = "Atualizar";  
  }    
  resetFrom()  
  {     
    this.getdata();  
    this.EstoqueForm.reset();  
    this.EventValue = "Salvar";  
    this.submitted = false;   
  } 
}