using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlattCodingChallenge.Models
{
	public class SingleFilmViewModel
	{
		public string Title { get; set; }

		[JsonProperty("episode_id")]
		public string EpisodeId { get; set; }

		public string Director { get; set; }

		[JsonProperty("release_date")]
		public string ReleaseDate { get; set; }
	}
}
