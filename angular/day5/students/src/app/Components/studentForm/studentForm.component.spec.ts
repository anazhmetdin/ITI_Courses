import { ComponentFixture, TestBed } from '@angular/core/testing';

import { studentFormComponent } from './studentForm.component';

describe('studentFormComponent', () => {
  let component: studentFormComponent;
  let fixture: ComponentFixture<studentFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ studentFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(studentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
