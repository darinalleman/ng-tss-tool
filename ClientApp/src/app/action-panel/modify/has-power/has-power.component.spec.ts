import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HasPowerComponent } from './has-power.component';

describe('HasPowerComponent', () => {
  let component: HasPowerComponent;
  let fixture: ComponentFixture<HasPowerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HasPowerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HasPowerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
