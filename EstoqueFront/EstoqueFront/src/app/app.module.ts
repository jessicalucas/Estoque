import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
// import {AppRoutingModule} from './app-rout'
// import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';  
import { HttpClientModule }    from '@angular/common/http';  
import { AppService } from './app.service'; 

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    // AppRoutingModule,
    FormsModule,  
    ReactiveFormsModule,  
    HttpClientModule  
  ],
  providers: [AppService],
  bootstrap: [AppComponent]
})
export class AppModule { }