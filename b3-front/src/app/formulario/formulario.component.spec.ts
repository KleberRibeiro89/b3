import { FormsModule } from '@angular/forms';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioComponent } from './formulario.component';
import { RouterTestingModule } from '@angular/router/testing';

describe('FormularioComponent', () => {
  let component: FormularioComponent;
  let fixture: ComponentFixture<FormularioComponent>;

  beforeEach(() => TestBed.configureTestingModule({
    imports: [RouterTestingModule, FormsModule],
    declarations: [FormularioComponent]
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormularioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('deve calcular corretamente o  total', () => {
    component.prazo = 6;
    component.valorAplicado = 100;

    component.calcular();
    expect(component.valorBruto).toBe(100);
  });

  it('deve exibir o total no template', () => {
    component.prazo = 6;
    component.valorAplicado = 100;

    component.calcular();
    expect(component.valorLiquido).toBe(100);
  });
});