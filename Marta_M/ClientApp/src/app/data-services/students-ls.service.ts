import { Injectable } from '@angular/core';
import { Student } from '../model/student';
import { StudentsService } from './students.service';

@Injectable()
export class StudentsLsService extends StudentsService {

  constructor()
  {
    super();
    this.readData();
  }

  insert(student: Student)
  {
    super.insert(student);
    this.saveData(student);
    this.saveNextId();
  }
  update(student: Student)
    {
      super.update(student);
      this.saveData(student);
    }
  detele(student: Student)
  {
    super.delete(student);
    let ls = window.localStorage;
    ls.removeItem(student.Id.toString());
  }

  private readData()
  {
    let ls = window.localStorage;
    for (let i = 0; i < ls.lenght; i++) {
      let k = ls.key(i);
      if (k != "nextId") { 
      let stud = JSON.parse(ls.getItem(k));
      this.collection.push(stud);
      }
    }
    this.nextId = parseInt(ls.getItem("nextId"));
    if (isNaN(this.nextId))
      this.nextId = 1;
  }

  private saveData(student: Student)
  {
    let ls = window.localStorage;
    ls.setItem(student.Id.toString(), JSON.stringify(student));
  }

  private saveNextId()
  {
    let ls = window.localStorage;
    ls.setItem("nextId", this.nextId.toString());
  }

}
