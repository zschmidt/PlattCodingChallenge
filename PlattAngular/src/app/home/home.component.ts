import { Component, OnInit } from '@angular/core';
import { PlanetDetailsViewModel } from '../models/PlanetDetailsViewModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

	planet: PlanetDetailsViewModel;

	constructor() { }

	ngOnInit() {
	}

	planetSelected(planet: PlanetDetailsViewModel) {
		this.planet = planet;
	}

}
