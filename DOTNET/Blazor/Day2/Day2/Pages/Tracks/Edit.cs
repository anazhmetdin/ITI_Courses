using Data.Models;
using Data;
using Microsoft.AspNetCore.Components;
using Day2.Services;

namespace Day2.Pages.Tracks
{
    public partial class Edit
    {
		[Parameter]
		public int Id { get; set; }
		public Track? Track { get; set; }
		public bool Saved { get; set; } = false;

        [Inject]
        protected TrackService _trackService { get; set; }

        protected override async Task OnInitializedAsync()
		{
			Track = await _trackService.GetTrackAsync(Id);

			await base.OnInitializedAsync();
		}

        protected async Task HandleValidSubmit()
        {
            if (Track != null)
            {
                Saved = await _trackService.UpdateTrackAsync(Id, Track);

            }
        }

        protected void HandleInvalidSubmit()
        {
            Saved = false;
        }
    }
}
