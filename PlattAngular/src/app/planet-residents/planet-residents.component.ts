import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { PlanetDetailsViewModel } from '../models/PlanetDetailsViewModel';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { PlanetResidentsViewModel } from '../models/PlanetResidentsViewModel';
import { ResidentSummary } from '../models/ResidentSummary';

@Component({
  selector: 'app-planet-residents',
  templateUrl: './planet-residents.component.html',
  styleUrls: ['./planet-residents.component.scss']
})
export class PlanetResidentsComponent implements OnInit, OnChanges {

	@Input() inputPlanet: PlanetDetailsViewModel;

	residents: ResidentSummary[];

	isLoading = false;

	constructor(
		private http: HttpClient) { }

	ngOnInit() {
	}

	ngOnChanges() {
		if(this.inputPlanet) {
			this.isLoading = true;
			this.http.get<PlanetResidentsViewModel>(`${environment.baseApiUrl}/residents/${this.inputPlanet.Name}/`).subscribe(data => {
				this.residents = data.Residents;
				this.isLoading = false;
			})
		}
	}

}
