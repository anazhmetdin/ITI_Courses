using Data;
using Data.Models;
using Day2.Services;
using Microsoft.AspNetCore.Components;

namespace Day2.Pages.Tracks
{
	public partial class Details
	{
		[Parameter]
		public int Id { get; set; }
		public Track? Track { get; set; }
		public List<Trainee> Trainees { get; set; } = new List<Trainee>();

        [Inject]
        protected TrackService _trackService { get; set; }

        protected override async Task OnInitializedAsync()
		{
			Track = await _trackService.GetTrackAsync(Id);

			await base.OnInitializedAsync();
		}
	}
}
