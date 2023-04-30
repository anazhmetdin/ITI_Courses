using Data.Models;
using Day2.Services;
using Microsoft.AspNetCore.Components;

namespace Day2.Pages.Tracks
{
	public partial class Create
	{
		public Track Track { get; set; } = new Track();
		public bool Saved { get; set; } = false;

        [Inject]
        protected TrackService _trackService { get; set; }

        public async Task CreateTrack()
		{
			Saved = await _trackService.AddTrackAsync(Track);
		}
	}
}
