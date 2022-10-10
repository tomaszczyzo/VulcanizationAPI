import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VulcanizationsListComponent } from './vulcanizations-list.component';

describe('VulcanizationsListComponent', () => {
  let component: VulcanizationsListComponent;
  let fixture: ComponentFixture<VulcanizationsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VulcanizationsListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VulcanizationsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
