import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormAirlineComponent } from './form-airline.component';

describe('FormAirlineComponent', () => {
  let component: FormAirlineComponent;
  let fixture: ComponentFixture<FormAirlineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormAirlineComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormAirlineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
