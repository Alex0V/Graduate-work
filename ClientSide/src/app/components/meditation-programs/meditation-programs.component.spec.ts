import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MeditationProgramsComponent } from './meditation-programs.component';

describe('MeditationProgramsComponent', () => {
  let component: MeditationProgramsComponent;
  let fixture: ComponentFixture<MeditationProgramsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MeditationProgramsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MeditationProgramsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
