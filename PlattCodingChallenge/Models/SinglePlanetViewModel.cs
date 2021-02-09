using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlattCodingChallenge.Models
{
	public class SinglePlanetViewModel
	{
		public string Name { get; set; }

		[JsonProperty("rotation_period")]
		public string LengthOfDay { get; set; }

		[JsonProperty("orbital_period")]
		public string LengthOfYear { get; set; }

		public string Diameter { get; set; }

		public string Climate { get; set; }

		public string Gravity { get; set; }

		[JsonProperty("surface_water")]
		public string SurfaceWaterPercentage { get; set; }

		public string Population { get; set; } = "0";

		public List<string> Residents { get; set; }
	}
}
