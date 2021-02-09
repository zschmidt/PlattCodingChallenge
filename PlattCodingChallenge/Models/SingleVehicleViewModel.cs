using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlattCodingChallenge.Models
{
	public class SingleVehicleViewModel
	{
		public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        [JsonProperty("cost_in_credits")]
        public string Cost { get; set; }

        public double FormattedCost => Cost == "unknown" ? -1 : double.Parse(Cost);
	}
}
