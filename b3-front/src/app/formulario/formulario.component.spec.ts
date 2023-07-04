import { Observable } from 'rxjs/internal/Observable';
import { FormsModule } from '@angular/forms';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioComponent } from './formulario.component';
import { RouterTestingModule } from '@angular/router/testing';
import { CdbService } from '../services/cdb.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CdbResultModel } from '../models/CdbResultModel';
import { delay, lastValueFrom, timeout } from 'rxjs';

describe('FormularioComponent', () => {
  let component: FormularioComponent;
  let fixture: ComponentFixture<FormularioComponent>;
  let service: CdbService;
  beforeEach(() => TestBed.configureTestingModule({
    imports: [RouterTestingModule, FormsModule, HttpClientModule],
    declarations: [FormularioComponent]
  }));

  beforeEach(() => {
    service = TestBed.inject(CdbService);

    fixture = TestBed.createComponent(FormularioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('Solicitar Calculo de Cdb Com valor Positivo', async () => {
    component.model.prazo = 2;
    component.model.valorAplicado = 1;
    component.valorMonetario = 'R$ 1';

    component.calcular()
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));

    expect(component.result.bruto > 0).toBe(true);
  });

  it('Solicitar Calculo de Cdb Com valor Negativo', async () => {
    component.model.prazo = 6;
    component.model.valorAplicado = -1;
    component.valorMonetario = 'R$ -1';

    component.calcular()
    const result = await lastValueFrom(service.calcularCDB(component.model)).catch((error)=>{
      let objError = error.error;
      expect(objError.liquido).toBe(0)
    });
  });

  it('Solicitar Calculo de Cdb Com Mes igual á 1', async () => {
    component.model.prazo = 1;
    component.model.valorAplicado = 1;
    component.valorMonetario = 'R$ 1';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model)).catch((error)=>{
      let objError = error.error;
      expect(objError.liquido).toBe(0)
    });



  });

  it('Testar Cálculo, resultado Líquido', async () => {
    component.model.prazo = 6;
    component.model.valorAplicado = 100;
    component.valorMonetario = 'R$ 100';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    expect(component.result.liquido).toBe(104.63);


  });

  it('Testar Cálculo, resultado Líquido', async () => {
    component.model.prazo = 12;
    component.model.valorAplicado = 100;
    component.valorMonetario = 'R$ 100';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    expect(component.result.liquido).toBe(109.85);

  });

  it('Testar Cálculo, resultado Bruto', async () => {
    component.model.prazo = 6;
    component.model.valorAplicado = 100;
    component.valorMonetario = 'R$ 100';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    expect(component.result.bruto).toBe(105.98);

  });


  it('Testar Cálculo, resultado Bruto 2 meses', async () => {
    component.model.prazo = 2;
    component.model.valorAplicado = 1000;
    component.valorMonetario = 'R$ 1.000,00';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    expect(component.result.bruto).toBe(1019.53);
  });


  it('Testar Cálculo, resultado Bruto 3 meses', async () => {
    component.model.prazo = 3;
    component.model.valorAplicado = 1000;
    component.valorMonetario = 'R$ 1.000,00';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    expect(component.result.bruto).toBe(1029.44);
  });

  it('Testar Cálculo, resultado Bruto 4 meses', async () => {
    component.model.prazo = 4;
    component.model.valorAplicado = 1000;
    component.valorMonetario = 'R$ 1.000,00';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    expect(component.result.bruto).toBe(1039.45);
  });

  it('Testar Cálculo, resultado Bruto 5 meses', async () => {
    component.model.prazo = 5;
    component.model.valorAplicado = 1000;
    component.valorMonetario = 'R$ 1.000,00';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    expect(component.result.bruto).toBe(1049.55);
  });

  it('Testar Cálculo, resultado Bruto 6 meses', async () => {
    component.model.prazo = 6;
    component.model.valorAplicado = 1000;
    component.valorMonetario = 'R$ 1.000,00';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    expect(component.result.bruto).toBe(1059.76);
  });

  it('Testar Cálculo, resultado Bruto 7 meses', async () => {
    component.model.prazo = 7;
    component.model.valorAplicado = 1000;
    component.valorMonetario = 'R$ 1.000,00';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    expect(component.result.bruto).toBe(1070.06);
  });

  it('Testar Cálculo, resultado Bruto 8 meses', async () => {
    component.model.prazo = 8;
    component.model.valorAplicado = 1000;
    component.valorMonetario = 'R$ 1.000,00';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    console.log(result);
    expect(component.result.bruto).toBe(1080.46);
  });

  it('Testar Cálculo, resultado Bruto 9 meses', async () => {
    component.model.prazo = 9;
    component.model.valorAplicado = 1000;
    component.valorMonetario = 'R$ 1.000,00';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    expect(component.result.bruto).toBe(1090.96);
  });

  it('Testar Cálculo, resultado Bruto 10 meses', async () => {
    component.model.prazo = 10;
    component.model.valorAplicado = 1000;
    component.valorMonetario = 'R$ 1.000,00';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    expect(component.result.bruto).toBe(1101.56);
  });

  it('Testar Cálculo, resultado Bruto 11 meses', async () => {
    component.model.prazo = 11;
    component.model.valorAplicado = 1000;
    component.valorMonetario = 'R$ 1.000,00';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    expect(component.result.bruto).toBe(1112.27);
  });

  it('Testar Cálculo, resultado Bruto 12 meses', async () => {
    component.model.prazo = 12;
    component.model.valorAplicado = 1000;
    component.valorMonetario = 'R$ 1.000,00';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model).pipe(timeout(10000)));
    expect(component.result.bruto).toBe(1123.08);
  });

});
