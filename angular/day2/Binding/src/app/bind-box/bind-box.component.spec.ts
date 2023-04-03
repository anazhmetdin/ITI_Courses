import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BindBoxComponent } from './bind-box.component';

describe('BindBoxComponent', () => {
  let component: BindBoxComponent;
  let fixture: ComponentFixture<BindBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BindBoxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BindBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
