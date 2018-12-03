import {Component, OnDestroy, OnInit} from '@angular/core';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-preguntas',
  templateUrl: './preguntas.component.html',
  styleUrls: ['./preguntas.component.css']
})
export class PreguntasComponent implements OnInit, OnDestroy {

  private preguntas;
  private preguntaSub;

  constructor(private ApiSvc: ApiService) { }

  ngOnInit() {
    this.preguntaSub = this.ApiSvc.getEntities('pregunta')
      .subscribe(
        (resp: any) => {
          this.preguntas = resp;
        },
        (error: any) => {
          console.log('Error en conexión: ' + error);
        }
      );
  }

  ngOnDestroy(): void {
    this.preguntaSub.unsubscribe();
  }

}
