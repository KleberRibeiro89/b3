import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss']
})
export class FormularioComponent {
  title = 'Calculadora CDB';
  valorAplicado: number | undefined;
  prazo: number | undefined;

  valorBruto: number;
  valorLiquido: number;
  constructor() {
    this.valorBruto = 0;
    this.valorLiquido = 0;
  }

  limparInput() {
    this.valorAplicado = 0;
    this.prazo = 1;
  }

  calcular() {
    this.valorLiquido = 100.10;
    this.valorBruto = 101.10;
  }

}
