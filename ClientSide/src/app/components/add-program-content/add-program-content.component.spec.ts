import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProgramContentComponent } from './add-program-content.component';

describe('AddProgramContentComponent', () => {
  let component: AddProgramContentComponent;
  let fixture: ComponentFixture<AddProgramContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddProgramContentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddProgramContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
