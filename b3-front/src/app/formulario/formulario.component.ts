import { CdbCommandModel } from '../models/CdbCommandModel';
import { Component, OnInit } from '@angular/core';
import { CdbService } from '../services/cdb.service';
import { CdbResultModel } from '../models/CdbResultModel';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss']
})
export class FormularioComponent {
  title = 'Calculadora CDB';

  model: CdbCommandModel = new CdbCommandModel();
  result!: CdbResultModel;

  constructor(private _service: CdbService) {

  }

  limparInput() {
    this.model.prazo = 0;
    this.model.valorAplicado = 0;
  }

  calcular() {
    this._service.calcularCDB(this.model)
      .subscribe({
        next: (result) => {
          this.result = result;
        },
        error: (error) => {
          this.result = error;
        }
      })
  }

}
