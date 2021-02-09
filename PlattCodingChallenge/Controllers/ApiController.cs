using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlattCodingChallenge.Models;
using System.Linq;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;

namespace PlattCodingChallenge.Controllers
{
	public class ApiController : Controller
	{
		private static readonly HttpClient client = new HttpClient();


        [HttpGet]
        [Route("api/planets")]
        [SwaggerOperation(
            Summary = "Gets all planets in the Star Wars universe",
            Description = "Returns a list of all known planets, sorted by diameter descending"
        )]
        [SwaggerResponse(200, "Returns list of all planets", typeof(AllPlanetsViewModel))]
        [Produces(typeof(AllPlanetsViewModel))]
		public async Task<AllPlanetsViewModel> GetAllPlanets()
		{
			var model = new AllPlanetsViewModel();

			var responseString = await client.GetStringAsync("https://swapi.dev/api/planets/");

			var allPlanetsPagination = Newtonsoft.Json.JsonConvert.DeserializeObject<AllPlanetsPaginationModel>(responseString);
			model.Planets.AddRange(allPlanetsPagination.Results);
			while (allPlanetsPagination.NextUrl != null) {
				responseString = await client.GetStringAsync(allPlanetsPagination.NextUrl);
				allPlanetsPagination = Newtonsoft.Json.JsonConvert.DeserializeObject<AllPlanetsPaginationModel>(responseString);
				model.Planets.AddRange(allPlanetsPagination.Results);
			}
			model.CalculateAverageDiameter();
			model.Planets = model.Planets.OrderByDescending(x => x.NumericDiameter).ToList();

			return model;
		}

        [HttpGet]
        [Route("api/planets/{planetid}")]
        [SwaggerOperation(
            Summary = "Gets all information about a particular planet",
            Description = "Returns all information about a planet as specified by a unique ID"
        )]
        [SwaggerResponse(200, "Returns the planet in question", typeof(SinglePlanetViewModel))]
        [Produces(typeof(SinglePlanetViewModel))]
		public async Task<SinglePlanetViewModel> GetPlanetById(int planetid)
		{
			var model = new SinglePlanetViewModel();

			var responseString = await client.GetStringAsync($"https://swapi.dev/api/planets/{planetid}/");

			model = Newtonsoft.Json.JsonConvert.DeserializeObject<SinglePlanetViewModel>(responseString);

			return model;
		}

        [HttpGet]
        [Route("api/residents/{planetname}")]
        [SwaggerOperation(
            Summary = "Gets all information about a particular planet by name",
            Description = "Returns all information about a planet as specified by the name"
        )]
        [SwaggerResponse(200, "Returns the planet in question", typeof(PlanetResidentsViewModel))]
        [Produces(typeof(PlanetResidentsViewModel))]
		public async Task<PlanetResidentsViewModel> GetResidentsOfPlanet(string planetname)
		{
			var model = new PlanetResidentsViewModel();

			var responseString = await client.GetStringAsync($"https://swapi.dev/api/planets/?search={planetname}");

			var searchObject = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchModel>(responseString);

			foreach (SinglePlanetViewModel planet in searchObject.Results)
			{
				if(String.Compare(planet.Name.ToLower(), planetname.ToLower()) == 0) {
					//We found our planet!
					foreach (var residentUrl in planet.Residents) {
						var residentString = await client.GetStringAsync(residentUrl);
						model.Residents.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<ResidentSummary>(residentString));
					}
				}
			}

			model.Residents = model.Residents.OrderBy(x => x.Name).ToList();

			return model;
		}

        [HttpGet]
        [Route("api/vehicles")]
        [SwaggerOperation(
            Summary = "Gets some information about all known vehicles",
            Description = "Returns information regarding all known vehicles in the Star Wars universe, grouped by manufacturer"
        )]
        [SwaggerResponse(200, "Returns a list of the number of manufacturers and the number of vehicles that each produces", typeof(PlanetResidentsViewModel))]
        [Produces(typeof(VehicleSummaryViewModel))]
		public async Task<VehicleSummaryViewModel> VehicleSummary()
		{
			var model = new VehicleSummaryViewModel();

			var responseString = await client.GetStringAsync("https://swapi.dev/api/vehicles/");

			var vehicleList = new List<SingleVehicleViewModel>();

			var allVehiclesPagination = Newtonsoft.Json.JsonConvert.DeserializeObject<AllVehiclesPaginationModel>(responseString);
			vehicleList.AddRange(allVehiclesPagination.Vehicles);
			while (allVehiclesPagination.NextUrl != null) {
				responseString = await client.GetStringAsync(allVehiclesPagination.NextUrl);
				allVehiclesPagination = Newtonsoft.Json.JsonConvert.DeserializeObject<AllVehiclesPaginationModel>(responseString);
				vehicleList.AddRange(allVehiclesPagination.Vehicles);
			}

			//A little suspicious whether this number is supposed to be before or after filtering...
			model.ManufacturerCount = vehicleList.GroupBy(x => x.Manufacturer.ToLower()).ToList().Count;
			
			vehicleList = vehicleList.Where(x => x.Cost != "unknown").ToList();

			model.Details = vehicleList.GroupBy(x => x.Manufacturer.ToLower()).Select(group => new VehicleStatsViewModel{ 
                             ManufacturerName = group.Key, 
                             VehicleCount = group.Count(),
							 AverageCost = group.Average(x => x.FormattedCost)
                        }).OrderByDescending(x => x.VehicleCount).ThenByDescending(x => x.AverageCost).ToList();
			
			model.VehicleCount = vehicleList.Count;

			return model;
		}
    }
}
