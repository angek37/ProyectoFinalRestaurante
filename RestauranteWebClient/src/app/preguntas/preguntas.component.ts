import {Component, OnDestroy, OnInit} from '@angular/core';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-preguntas',
  templateUrl: './preguntas.component.html',
  styleUrls: ['./preguntas.component.css']
})
export class PreguntasComponent implements OnInit, OnDestroy {
  preguntas;
  private preguntaSub;
  loading = true;

  constructor(private ApiSvc: ApiService) { }

  ngOnInit() {
    this.preguntaSub = this.ApiSvc.getEntities('pregunta')
      .subscribe(
        (resp: any) => {
          this.preguntas = resp;
          this.preguntas.sort((obj1, obj2) => {
            if (obj1.preguntaId > obj2.preguntaId) {
              return 1;
            }

            if (obj1.preguntaId < obj2.preguntaId) {
              return -1;
            }

            return 0;
          });
          this.loading = false;
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
