import { Component, OnInit } from '@angular/core';
import { Student } from '../model/student';
import { StudentsService } from '../data-services/students.service';
import { FormGroup } from '@angular/forms/src/model';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {
  
  students: Student[] = [];
  editStudent: Student;
  sum: number;
  TotalGrant: number;
  private form: FormGroup;

  constructor(private dataService: StudentsService, private formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      Id: this.formBuilder.control(0),
      FirstName: this.formBuilder.control(),
      LastName: this.formBuilder.control(),
      Grant: this.formBuilder.control()


    });


    this.computeSum();

  }

  add() {
    //this.editStudent = new Student();
    this.form.setValue(new Student());
    this.computeSum();
  }

  edit(student) {
    this.form.setValue(Object.assign(new Student(), student));
    this.computeSum();

  } 

  delete(student) {
    let index = this.students.indexOf(student);
    this.students.splice(index, 1);
    this.computeSum();
  }

  save() {
    let obj = this.form.value;
    if (obj.Id == 1) {
      this.dataService.insert(<Student>obj);

    }

    //if (this.editStudent.Id == undefined) {
    //  this.dataService.insert(this.editStudent)
    
    else {
      this.dataService.update(<Student> obj);
    }

    this.editStudent = null;
    this.computeSum();
  }
  cancel() {
    this.editStudent = null;

  }

  computeSum() {
    this.sum = this.students.reduce((s, cv) => s + cv.Grant, 0);
  }

}
