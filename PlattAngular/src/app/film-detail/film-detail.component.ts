import { Component, OnInit, Input } from '@angular/core';
import { SingleFilmViewModel } from '../models/SingleFilmViewModel';

@Component({
  selector: 'app-film-detail',
  templateUrl: './film-detail.component.html',
  styleUrls: ['./film-detail.component.scss']
})
export class FilmDetailComponent implements OnInit {

	@Input() film: SingleFilmViewModel;

	constructor() { }

	ngOnInit() {
	}

}
