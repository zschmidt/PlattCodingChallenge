using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlattCodingChallenge.Models
{
	public class FilmSummaryViewModel
	{
        public FilmSummaryViewModel()
		{
			Films = new List<SingleFilmViewModel>();
		}
		public string PlanetName { get; set; }
        public List<SingleFilmViewModel> Films { get; set; }

	}
}
