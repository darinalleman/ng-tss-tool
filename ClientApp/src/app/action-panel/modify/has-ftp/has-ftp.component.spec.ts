import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { HasFtpComponent } from './has-ftp.component';

describe('HasFtpComponent', () => {
  let component: HasFtpComponent;
  let fixture: ComponentFixture<HasFtpComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ HasFtpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HasFtpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
