import { Component, OnInit } from '@angular/core';
import { Hero } from '../models/hero';
// import { HEROES } from '../models/mock-heroes';
import { HeroService } from '../hero.service';

/**
 * @ Component is a decorator function that specifies the Angular metadata for the component.
 */
@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})
export class HeroesComponent implements OnInit {
  // heroes = HEROES;
  heroes: Hero[];
  // selectedHero: Hero;

  // defines a private heroService property and identifies it as a HeroService injection site.
  constructor(private heroService: HeroService) { }

  /*
  getHeroes(): void {
    // has a synchronous signature, which implies that the HeroService can fetch heroes synchronously
    this.heroes = this.heroService.getHeroes();
  }
  */

  //waits for the Observable to emit the array of heroes— which could happen now or several minutes from now. Then subscribe passes the emitted array to the callback, which sets the component's heroes property.
  // This asynchronous approach will work when the HeroService requests heroes from the server.
  getHeroes(): void {
    this.heroService.getHeroes()
      .subscribe(heroes => this.heroes = heroes);
  }

  //  is a lifecycle hook. Angular calls ngOnInit shortly after creating a component. It's a good place to put initialization logic.
  //  let Angular call ngOnInit at an appropriate time after constructing a HeroesComponent instance.
  ngOnInit() {
    this.getHeroes();
  }

  // onSelect(hero: Hero): void {
  //   this.selectedHero = hero;
  // }
}
