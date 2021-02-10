using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlattCodingChallenge.Models
{
	public class PlanetDetailsViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }

		public string Population { get; set; }

		public string Diameter { get; set; }

		public string Terrain { get; set; }

		[JsonProperty("orbital_period")]
		public string LengthOfYear { get; set; }

		//This is just a convenient place for me to try to parse out the id
		public string Url { get; set; }

		//how big *is* unknown?
		public int NumericDiameter => Diameter == "unknown" ? -1 : int.Parse(Diameter);

		public string FormattedPopulation => Population == "unknown" ? "unknown" : long.Parse(Population).ToString("N0");
    }
}
