import { FormsModule } from '@angular/forms';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioComponent } from './formulario.component';
import { RouterTestingModule } from '@angular/router/testing';
import { CdbService } from '../services/cdb.service';

describe('FormularioComponent', () => {
  let component: FormularioComponent;
  let fixture: ComponentFixture<FormularioComponent>;
  let service: CdbService;

  beforeEach(() => TestBed.configureTestingModule({
    imports: [RouterTestingModule, FormsModule],
    declarations: [FormularioComponent]
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormularioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('Solicitar Calculo de Cdb Com valor Positivo', () => {
    component.model.prazo = 2;
    component.model.valorAplicado = 1;

    service.calcularCDB(component.model);
    expect(component.result.bruto > 0).toBeTrue();
  });

  it('Solicitar Calculo de Cdb Com valor Negativo', () => {
    component.model.prazo = 6;
    component.model.valorAplicado = -1;

    service.calcularCDB(component.model);
    expect(component.result.liquido).toBe(0);
  });

  it('Solicitar Calculo de Cdb Com Mes igual á 1', () => {
    component.model.prazo = 1;
    component.model.valorAplicado = 1;

    service.calcularCDB(component.model);
    expect(component.result.liquido).toBe(0);
  });

  it('Testar Cálculo, resultado Líquido', () => {
    component.model.prazo = 6;
    component.model.valorAplicado = 100;

    service.calcularCDB(component.model);
    expect(component.result.liquido).toBe(105.01);
  });

  it('Testar Cálculo, resultado Líquido', () => {
    component.model.prazo = 12;
    component.model.valorAplicado = 100;

    service.calcularCDB(component.model);
    expect(component.result.liquido).toBe(109.88);
  });

  it('Testar Cálculo, resultado Bruto', () => {
    component.model.prazo = 6;
    component.model.valorAplicado = 100;

    service.calcularCDB(component.model);
    expect(component.result.bruto).toBe(106.47);
  });
});
