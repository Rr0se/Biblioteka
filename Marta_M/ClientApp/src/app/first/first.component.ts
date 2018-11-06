import { Component } from "@angular/core/src/metadata/directives";

@Component({
  selector: "first",
  template: "<h1> {{message}}</h1>"
})

export class FirstComponent
{
  private message = "Hello World!";

}
