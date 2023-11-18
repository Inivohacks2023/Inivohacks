import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RebrandComponent } from './rebrand.component';

describe('RebrandComponent', () => {
  let component: RebrandComponent;
  let fixture: ComponentFixture<RebrandComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RebrandComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RebrandComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
