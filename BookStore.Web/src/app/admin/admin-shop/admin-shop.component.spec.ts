import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminShopComponent } from './admin-shop.component';

describe('AdminShopComponent', () => {
  let component: AdminShopComponent;
  let fixture: ComponentFixture<AdminShopComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminShopComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminShopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
