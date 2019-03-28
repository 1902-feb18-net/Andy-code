import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HeroesComponent } from './heroes/heroes.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HeroDetailComponent } from './hero-detail/hero-detail.component';

// Routes tell the router which view to display when a user clicks a link or pastes a URL into the browser address bar.
// 2 properties
// 1. path: a string that matches the URL in the browser address bar.
// 2. component: the component that the router should create when navigating to this route.
const routes: Routes = [
  // Then define an array of routes with a single route to that component.
  {path: '', redirectTo: '/dashboard', pathMatch: 'full'},
  { path: 'dashboard', component: DashboardComponent },
  { path: 'detail/:id', component: HeroDetailComponent },
  {path: 'heroes', component: HeroesComponent}
  // The colon (:) in the path indicates that :id is a placeholder for a specific hero id.
];

@NgModule({
  // You first must initialize the router and start it listening for browser location changes.
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
