import { Component, OnInit, Input } from '@angular/core';
import { ResidentSummary } from '../models/ResidentSummary';

@Component({
  selector: 'app-planet-resident-detail',
  templateUrl: './planet-resident-detail.component.html',
  styleUrls: ['./planet-resident-detail.component.scss']
})
export class PlanetResidentDetailComponent implements OnInit {

	@Input() resident: ResidentSummary;

	constructor() { }

	ngOnInit() {
	}

}
