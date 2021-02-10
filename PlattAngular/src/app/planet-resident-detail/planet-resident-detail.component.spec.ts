import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanetResidentDetailComponent } from './planet-resident-detail.component';

describe('PlanetResidentDetailComponent', () => {
  let component: PlanetResidentDetailComponent;
  let fixture: ComponentFixture<PlanetResidentDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlanetResidentDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanetResidentDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
