import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { AllPlanetsViewModel } from '../models/AllPlanetsViewModel';
import { PlanetDetailsViewModel } from '../models/PlanetDetailsViewModel';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-planets',
  templateUrl: './planets.component.html',
  styleUrls: ['./planets.component.scss']
})
export class PlanetsComponent implements OnInit {

	displayedColumns: string[] = ['name', 'population', 'diameter', 'terrain', 'lengthOfYear'];

	planets: MatTableDataSource<PlanetDetailsViewModel>;

	allPlanetsViewModel: AllPlanetsViewModel;

	isLoading = true;

	@ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;

	@Output() planetSelected = new EventEmitter<PlanetDetailsViewModel>();


	constructor(
		private http: HttpClient
		) {
	}

	ngOnInit() {
		this.http.get<AllPlanetsViewModel>(`${environment.baseApiUrl}/planets`).subscribe(data => {
			this.allPlanetsViewModel = data;
			this.planets = new MatTableDataSource(this.allPlanetsViewModel.Planets);
			this.isLoading = false;
			this.planets.paginator = this.paginator;
		})  
	}

	selectPlanet(planet: PlanetDetailsViewModel) {
		this.planetSelected.emit(planet);
	}

}
