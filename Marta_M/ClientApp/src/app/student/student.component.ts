import { Component, OnInit } from '@angular/core';
import { Student } from '../model/student';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  students: Student[] = [];
  editObject: Student;
  nextId: number = 1;
  sum: number;
  

  constructor() { }

  ngOnInit() {
  }

  add() {
    this.editObject = new Student();

  }

  edit(student) {
    this.editObject = Object.assign(new Student(), student);
  }

  delete() {

  }

  save() {
    if (this.editObject.Id == undefined) {
      this.editObject.Id = this.nextId++;
      this.students.push(this.editObject);
      this.editObject = null;
    }
    else {
      var student = this.students.find(s => s.Id == this.editObject.Id);
      Object.assign(student, this.editObject);
    }
  }
  cancel() {
    this.editObject = null;

  }

  computeSum() {
    this.sum = this.students.reduce((s, cv) => s + cv.Grant, 0);
  }

}
