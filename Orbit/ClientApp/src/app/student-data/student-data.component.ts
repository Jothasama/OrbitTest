import { Component, Inject, NgModule } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@NgModule({
  imports: [
    FormGroup,
    FormControl,
    Validators
  ],
  declarations: [
    StudentComponent
  ]
})
@Component({
  selector: 'app-student-data',
  templateUrl: './student-data.component.html'
})
export class StudentComponent {
  students: Student[];
  studentForm: FormGroup;
  submitted = false;
  eventValue: any = "Save";
  url: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.url = baseUrl + 'student';
    this.get();

    this.studentForm = new FormGroup({
      id: new FormControl(0),
      username: new FormControl("", [Validators.required, Validators.maxLength(20)]),
      firstName: new FormControl("", [Validators.required, Validators.maxLength(20)]),
      lastName: new FormControl("", [Validators.required, Validators.maxLength(20)]),
      age: new FormControl("", [Validators.required]),
      career: new FormControl("", [Validators.required, Validators.maxLength(50)]),
    })
  } 

  get() {
    this.http.get<Student[]>(this.url).subscribe(result => {
      this.students = result;
    }, error => console.error(error));
  }

  post(formData) {
    return this.http.post(this.url, formData);
  }

  put(formData) {
    return this.http.put(this.url, formData);
  }

  delete(id) {
    return this.http.delete(this.url + '?id=' + id).subscribe(() => {
      this.resetFrom();
    })
  }

  Save() {
    this.submitted = true;
    if (this.studentForm.invalid) {
      return;
    }
    this.post(this.studentForm.value).subscribe(() => {
      this.resetFrom();
    })
  }
  Update() {
    this.submitted = true;

    if (this.studentForm.invalid) {
      return;
    }
    this.put(this.studentForm.value).subscribe(() => {
      this.resetFrom();
    })
  }

  Delete(id) {
    this.delete(id);
  }

  Edit(student) {
    this.studentForm.controls["id"].setValue(student.id);
    this.studentForm.controls["username"].setValue(student.username);
    this.studentForm.controls["firstName"].setValue(student.firstName);
    this.studentForm.controls["lastName"].setValue(student.lastName);
    this.studentForm.controls["age"].setValue(student.age);
    this.studentForm.controls["career"].setValue(student.career);
    this.eventValue = "Update";
  }

  resetFrom() {
    this.get();
    this.studentForm.reset();
    this.eventValue = "Save";
    this.submitted = false;
  }
}

interface Student {
  id: number;
  username: string;
  firstName: string;
  lastName: string;
  age: number;
  career: string;
}
