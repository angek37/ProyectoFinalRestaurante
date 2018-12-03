import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {PreguntasComponent} from './preguntas/preguntas.component';
import {RespuestasComponent} from './respuestas/respuestas.component';

const routes: Routes = [
  {path: '', component: PreguntasComponent},
  {path: 'respuestas', component: RespuestasComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
