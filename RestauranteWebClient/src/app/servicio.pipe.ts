import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'servicio'
})
export class ServicioPipe implements PipeTransform {

  private cadena: string;

  transform(value: any, args?: any): any {
    switch (value) {
      case true:
        this.cadena = 'Bueno';
        break;
      case false:
        this.cadena = 'Malo';
        break;
    }
    return this.cadena;
  }

}
