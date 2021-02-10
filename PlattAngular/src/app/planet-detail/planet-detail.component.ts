import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { PlanetDetailsViewModel } from '../models/PlanetDetailsViewModel';
import { SinglePlanetViewModel } from '../models/SinglePlanetViewModel';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-planet-detail',
  templateUrl: './planet-detail.component.html',
  styleUrls: ['./planet-detail.component.scss']
})
export class PlanetDetailComponent implements OnInit, OnChanges {

	@Input() inputPlanet: PlanetDetailsViewModel;

	planet: SinglePlanetViewModel;
	isLoading = false;

	constructor(
		private http: HttpClient) { }

	ngOnInit() {
	}

	ngOnChanges() {
		if(this.inputPlanet) {
			this.isLoading = true;
			this.http.get<SinglePlanetViewModel>(`${environment.baseApiUrl}/planets/${this.inputPlanet.Id}/`).subscribe(data => {
				this.planet = data;
				this.isLoading = false;
			})
		}
	}

}
