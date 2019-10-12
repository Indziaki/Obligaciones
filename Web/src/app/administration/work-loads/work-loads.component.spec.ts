import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkLoadsComponent } from './work-loads.component';

describe('WorkLoadsComponent', () => {
  let component: WorkLoadsComponent;
  let fixture: ComponentFixture<WorkLoadsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkLoadsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkLoadsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
