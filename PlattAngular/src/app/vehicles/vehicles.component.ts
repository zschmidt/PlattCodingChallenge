import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { AllPlanetsViewModel } from '../models/AllPlanetsViewModel';
import { VehicleStatsViewModel } from '../models/VehicleStatsViewModel';
import { VehicleSummaryViewModel } from '../models/VehicleSummaryViewModel';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-vehicles',
  templateUrl: './vehicles.component.html',
  styleUrls: ['./vehicles.component.scss']
})
export class VehiclesComponent implements OnInit {

	displayedColumns: string[] = ['manufacturerName', 'vehicleCount', 'averageCost'];

	vehicles: MatTableDataSource<VehicleStatsViewModel>;

	vehicleSummaryViewModel: VehicleSummaryViewModel;

	isLoading = true;

	@ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;


	constructor(
		private http: HttpClient
		) {
	}

	ngOnInit() {
		this.http.get<VehicleSummaryViewModel>(`${environment.baseApiUrl}/vehicles`).subscribe(data => {
			this.vehicleSummaryViewModel = data;
			this.vehicles = new MatTableDataSource(this.vehicleSummaryViewModel.Details);
			this.isLoading = false;
			this.vehicles.paginator = this.paginator;
		})  
	}

}
