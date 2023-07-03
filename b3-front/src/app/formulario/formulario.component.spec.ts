import { Observable } from 'rxjs/internal/Observable';
import { FormsModule } from '@angular/forms';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioComponent } from './formulario.component';
import { RouterTestingModule } from '@angular/router/testing';
import { CdbService } from '../services/cdb.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CdbResultModel } from '../models/CdbResultModel';
import { delay, lastValueFrom } from 'rxjs';

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
    const result = await lastValueFrom(service.calcularCDB(component.model));

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
    const result = await lastValueFrom(service.calcularCDB(component.model));
    expect(component.result.liquido).toBe(104.63);


  });

  it('Testar Cálculo, resultado Líquido', async () => {
    component.model.prazo = 12;
    component.model.valorAplicado = 100;
    component.valorMonetario = 'R$ 100';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model));
    expect(component.result.liquido).toBe(109.85);

  });

  it('Testar Cálculo, resultado Bruto', async () => {
    component.model.prazo = 6;
    component.model.valorAplicado = 100;
    component.valorMonetario = 'R$ 100';

    component.calcular();
    const result = await lastValueFrom(service.calcularCDB(component.model));
    expect(component.result.bruto).toBe(105.98);

  });
});
