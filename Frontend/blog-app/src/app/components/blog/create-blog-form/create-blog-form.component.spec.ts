import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateBlogFormComponent } from './create-blog-form.component';

describe('CreateBlogFormComponent', () => {
  let component: CreateBlogFormComponent;
  let fixture: ComponentFixture<CreateBlogFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateBlogFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateBlogFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
