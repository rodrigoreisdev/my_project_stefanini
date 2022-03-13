import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListComponent } from './list/list.component';
import { SharedService } from './shared.service';

import { CardModule } from 'primeng-lts/card';
import { ButtonModule } from 'primeng-lts/button';
import { DialogModule } from 'primeng-lts/dialog';
import {InputTextModule} from 'primeng-lts/inputtext';
import {InputMaskModule} from 'primeng-lts/inputmask';



@NgModule({
  declarations: [
    AppComponent,
    ListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CardModule,
    ButtonModule,
    DialogModule,
    BrowserAnimationsModule,
    FormsModule, 
    ReactiveFormsModule,
    InputTextModule,
    InputMaskModule,
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
