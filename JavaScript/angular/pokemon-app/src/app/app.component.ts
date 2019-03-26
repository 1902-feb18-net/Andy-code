import { Component } from '@angular/core';

// like a ng module, a componenet
// it is a class with a decorator on it that turns it into a component for ng

// a component is a class that references an HTML template
// to define a view
// a view is a physical area on the page with some logic to it and its own lifetime

@Component({
  // "selector" - define the selector for which elements in the HTML template
  // will get replaced by this component
  // this component needs a "name" so that we can put it into HTML
  // found outside in src folder
  selector: 'app-root',
  // define the template for a component in its decorator
  templateUrl: './app.component.html',
  // we could also have the template inline, like this:
  // template: `
  //   <ol>
  //     <li></li>
  //   </ol>
  // `,
  // dont usuallt do that except for very small templates
  styleUrls: ['./app.component.css']
  // specify css for this component, we can have many
  // also inline styles
  // styles: [
  //   ``,
  //   ``
  // ]
})

export class AppComponent {
  title = 'pokemon-app';
}
