import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MyPartiesPage } from './my-parties.page';

describe('MyPartiesPage', () => {
  let component: MyPartiesPage;
  let fixture: ComponentFixture<MyPartiesPage>;

  beforeEach(async(() => {
    fixture = TestBed.createComponent(MyPartiesPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
