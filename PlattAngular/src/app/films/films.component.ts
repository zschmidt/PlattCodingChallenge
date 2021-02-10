import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { PlanetDetailsViewModel } from '../models/PlanetDetailsViewModel';
import { FilmSummaryViewModel } from '../models/FilmSummaryViewModel';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-films',
  templateUrl: './films.component.html',
  styleUrls: ['./films.component.scss']
})
export class FilmsComponent implements OnInit {
	@Input() inputPlanet: PlanetDetailsViewModel;

	filmSummaryViewModel: FilmSummaryViewModel;
	isLoading = false;

	constructor(
		private http: HttpClient) { }

	ngOnInit() {
	}

	ngOnChanges() {
		if(this.inputPlanet) {
			this.isLoading = true;
			this.http.get<FilmSummaryViewModel>(`${environment.baseApiUrl}/planets/${this.inputPlanet.Id}/films`).subscribe(data => {
				this.filmSummaryViewModel = data;
				this.isLoading = false;
			})
		}
	}
}
