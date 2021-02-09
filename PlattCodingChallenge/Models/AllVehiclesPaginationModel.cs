using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlattCodingChallenge.Models
{
	public class AllVehiclesPaginationModel
	{
		public AllVehiclesPaginationModel(){}

        [JsonProperty("results")]
		public List<SingleVehicleViewModel> Vehicles { get; set; }

        [JsonProperty("next")]
		public string NextUrl { get; set; }

    }
}
