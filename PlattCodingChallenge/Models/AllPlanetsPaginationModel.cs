using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlattCodingChallenge.Models
{
	public class AllPlanetsPaginationModel
	{
		public AllPlanetsPaginationModel(){}

        [JsonProperty("results")]
		public List<PlanetDetailsViewModel> Results { get; set; }

        [JsonProperty("next")]
		public string NextUrl { get; set; }

    }
}
