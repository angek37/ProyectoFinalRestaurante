import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {
  NbCardModule,
  NbLayoutModule,
  NbMenuModule,
  NbSidebarModule,
  NbSidebarService,
  NbSpinnerModule,
  NbThemeModule
} from '@nebular/theme';
import { PreguntasComponent } from './preguntas/preguntas.component';
import {HttpClientModule} from '@angular/common/http';
import { RespuestasComponent } from './respuestas/respuestas.component';
import { ServicioPipe } from './servicio.pipe';

@NgModule({
  declarations: [
    AppComponent,
    PreguntasComponent,
    RespuestasComponent,
    ServicioPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NbThemeModule.forRoot(),
    NbLayoutModule,
    NbSidebarModule,
    NbCardModule,
    HttpClientModule,
    NbMenuModule.forRoot(),
    NbSpinnerModule,
  ],
  providers: [NbSidebarService],
  bootstrap: [AppComponent]
})
export class AppModule { }
