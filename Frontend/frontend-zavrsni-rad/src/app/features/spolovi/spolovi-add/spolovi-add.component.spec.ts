import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpoloviAddComponent } from './spolovi-add.component';

describe('SpoloviAddComponent', () => {
  let component: SpoloviAddComponent;
  let fixture: ComponentFixture<SpoloviAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpoloviAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpoloviAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
