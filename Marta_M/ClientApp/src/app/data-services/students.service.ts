import { Injectable } from '@angular/core';
import { Student } from '../model/student';

@Injectable()
export class StudentsService {

  collection: Student[] = [];
  nextId: number = 1;

  constructor()
  {
   
  }

  getAll()
  {
    return this.collection;
  }

  insert(student: Student)
  {
    student.Id = this.nextId++;
    this.collection.push(student);

  }

  update(student: Student)
  {
    let stud = this.collection.find(s => s.Id == student.Id);
    Object.assign(stud, student);
  }

  delete(student: Student)
  {
    let index = this.collection.indexOf(student);
    this.collection.splice(index, 1);
  }

}
