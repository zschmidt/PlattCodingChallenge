import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { PlanetsComponent } from './planets/planets.component';
import { HttpClientModule } from '@angular/common/http';
import { MatInputModule, MatPaginatorModule, MatProgressSpinnerModule, 
         MatSortModule, MatTableModule } from "@angular/material";
import { MatCardModule } from '@angular/material/card';
import { PlanetDetailComponent } from './planet-detail/planet-detail.component';
import { PlanetResidentsComponent } from './planet-residents/planet-residents.component';
import { VehiclesComponent } from './vehicles/vehicles.component';
import { MatListModule } from '@angular/material/list';
import { PlanetResidentDetailComponent } from './planet-resident-detail/planet-resident-detail.component';
import { FilmsComponent } from './films/films.component';
import { FilmDetailComponent } from './film-detail/film-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PlanetsComponent,
    PlanetDetailComponent,
    PlanetResidentsComponent,
    VehiclesComponent,
    PlanetResidentDetailComponent,
    FilmsComponent,
    FilmDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatProgressSpinnerModule,
    MatCardModule,
    MatListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
