import { CdbResultDataModel } from './../models/CdbResultModel';
import { CdbCommandModel } from '../models/CdbCommandModel';
import { Component, OnInit } from '@angular/core';
import { CdbService } from '../services/cdb.service';
import { CdbResultModel } from '../models/CdbResultModel';

import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss']
})
export class FormularioComponent {
  title = 'Calculadora CDB';

  valorMonetario: string = "";
  model: CdbCommandModel = new CdbCommandModel();
  result!: CdbResultModel;

  constructor(private _service: CdbService) {
    this.result = {} as CdbResultModel;
    this.result.bruto = 0;
    this.result.liquido = 0;
    this.result.data = [];
  }


  calcular(): void {
    this.model.valorAplicado = Number(this.valorMonetario.replace("R$", "").replace(' ', '').replace(/\./g, "").replace(',', '.'));
    this._service.calcularCDB(this.model)
      .subscribe({
        next: (result) => {
          this.result = result;
        },
        error: (error) => {
          this.result = error.error;
        }
      })
  }

  formatCurrency(event: any): void {
    let number = event.target.value.replace("R$", "").replace(' ', '').replace(/\./g, "").replace(',', '.');

    this.valorMonetario = new Intl.NumberFormat('pt-BR', {
      style: 'currency',
      currency: 'BRL'
    }).format(number);
  }
}
