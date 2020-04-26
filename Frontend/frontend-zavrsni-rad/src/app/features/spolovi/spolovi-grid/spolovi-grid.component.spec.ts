import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpoloviGridComponent } from './spolovi-grid.component';

describe('SpoloviGridComponent', () => {
  let component: SpoloviGridComponent;
  let fixture: ComponentFixture<SpoloviGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpoloviGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpoloviGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
