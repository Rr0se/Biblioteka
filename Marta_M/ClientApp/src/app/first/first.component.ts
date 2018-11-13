import { Component } from "@angular/core";

@Component({
  selector: "first",
  template: `<h1> {{message}}</h1> <button (click)='click()'>Zmien komunikat</button>
<button (click)='dodanie()'>dodac nowy obiekt</button>
<table><tr *ngFor="let obj of collection">
<td>{{obj.name}}</td>   
<td>{{obj.value}}</td>
<td><button (click)='edit(obj)'>edytuj</button></td>
</tr>
</table>
<div>
<label>name</label><input [(ngModel)]="newObject.name"/>
<label>value</label><input [(ngModel)]="newObject.value"/>
</div>
<button *ngIf="!editMode" (click)='clickk()'>dodac</button>` //zdarzenia w okrąglych nawiasach, jak chcemy w dwoch liniach to ``
  //to jest ta tabela zrobiona do wyswietlania kolecki ktora jest stworzona na dole
})

export class FirstComponent {
  private editMode = true;//do ukrycia przycisku dodawania
  private message = "hello world";
  click() {
    this.message = "zmieniony komunikat";
  }

  private collection = [{ name: "pierwszy ", value: 12 },
  { name: "drugi", value: 14 },
  { name: "trzeci", value: 16 }]

  //druga funkcja dodajaca pozycje w tabeli
  // clickk() {
  // this.collection.push({name:"fff",value:22})
  //}
  private newObject = { name: "", value: 0 };
  //dodaje po wpisaniu do listy 
  clickk() {
    //tak nie moze byc bo usuwa i zapisuje na biezao to co piszemy i widac to od razu
    // this.collection.push(this.newObject)
    this.collection.push({ name: this.newObject.name, value: this.newObject.value })
  }
  //FUNCKAJ do edytowania 
  edit(obj) {
    //przypisujemy do objektu newobject czyli te inputy
    this.newObject = obj;
  }
  dodanie() {
    this.newObject = { name: "", value: 0 };
    this.editMode = false;
  }
}
