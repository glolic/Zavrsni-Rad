import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpoloviEditComponent } from './spolovi-edit.component';

describe('SpoloviEditComponent', () => {
  let component: SpoloviEditComponent;
  let fixture: ComponentFixture<SpoloviEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpoloviEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpoloviEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
