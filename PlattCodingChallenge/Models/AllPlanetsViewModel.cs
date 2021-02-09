using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlattCodingChallenge.Models
{
	public class AllPlanetsViewModel
	{
		public AllPlanetsViewModel()
		{
			Planets = new List<PlanetDetailsViewModel>();
		}

		public List<PlanetDetailsViewModel> Planets { get; set; }

		public double AverageDiameter { get; set; }

		public void CalculateAverageDiameter() {
			double totalDiameter = 0;
			int count = Planets.Count;
			foreach (var planet in Planets) {
				if (planet.Diameter == "unknown") {
					//we just won't count this planet in to the average at all
					count--;
				} else {
					totalDiameter += int.Parse(planet.Diameter);
				}
			}
			AverageDiameter = count != 0 ? totalDiameter / count : 0;
		}
    }
}
