import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PokemonComponent } from './pokemon/pokemon.component';
import { HttpClientModule } from '@angular/common/http';

// decorators provides metadata that Angular needs
// to define this class as a (ng) module
@NgModule({
  // every component needs to be delcared in one module
  declarations: [
    AppComponent,
    PokemonComponent // root component
  ],
  // in "imports", we list all the other modules that we want components
  // and directives from
  imports: [
    BrowserModule,
    FormsModule, // for ngModel
    AppRoutingModule,
    HttpClientModule
    // to access something from some 3rd party npm package
    // or angular npm packages
    // 1. npm install <package>
    // 2. TS import it into the module file that needs it
    // 3. put it in the "imports" array (ng-import)
    // 
  ],
  providers: [],
  // sepcifically our root module should have a BS line
  // which points to the root component
  bootstrap: [AppComponent] // this defines our root component
})
export class AppModule { }
