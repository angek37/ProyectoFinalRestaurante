import {Component, OnDestroy, OnInit} from '@angular/core';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-respuestas',
  templateUrl: './respuestas.component.html',
  styleUrls: ['./respuestas.component.css']
})
export class RespuestasComponent implements OnInit, OnDestroy {
  private respuestas;
  private respuestasSub;
  private loading = true;

  constructor(private ApiSvc: ApiService) { }

  ngOnInit() {
    this.fetchData();
  }

  fetchData() {
    this.respuestasSub = this.ApiSvc.getEntities('respuesta')
      .subscribe(
        (resp: any) => {
          this.respuestas = resp;
          this.loading = false;
        },
        (error: any) => {
          console.log('Error:' + error);
        }
      );
  }

  ngOnDestroy(): void {
    this.respuestasSub.unsubscribe();
  }

  delete(id: number) {
    this.respuestasSub = this.ApiSvc.deleteEntity('respuesta', id)
      .subscribe(
        (resp: any) => {

        },
        (error: any) => {
          console.log('Error: ' + error);
        },
        () => {
          this.fetchData();
        }
      );
  }

}
