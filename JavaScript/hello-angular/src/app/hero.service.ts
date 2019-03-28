// must make the HeroService available to the dependency injection system before Angular can inject it into the HeroesComponent

import { Injectable } from '@angular/core';
import { Hero } from './models/hero';
import { HEROES } from './models/mock-heroes';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';

// This marks the class as one that participates in the dependency injection system.
// accepts a metadata object for the service, the same way the @Component() decorator did for your component classes.
@Injectable({
  // When you provide the service at the root level, Angular creates a single, shared instance of HeroService and injects into any class that asks for it
  providedIn: 'root'
})
export class HeroService {

  // Angular will inject the singleton MessageService into that property when it creates the HeroService.
  constructor(private messageService: MessageService) { }

  // Angular's HttpClient methods return RxJS Observables.
  getHeroes(): Observable<Hero[]> {
    // of(HEROES) returns an Observable<Hero[]> that emits a single value, the array of mock heroes.
    this.messageService.add('HeroService: fetched heroes');
    return of(HEROES);
  }

  // getHero() has an asynchronous signature. It returns a mock hero as an Observable, using the RxJS of() function.
  getHero(id: number): Observable<Hero> {
    // TODO: send the message _after_ fetching the hero
    this.messageService.add(`HeroService: fetched hero id=${id}`);
    return of(HEROES.find(hero => hero.id === id));
  }
}
