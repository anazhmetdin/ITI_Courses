using Data.Models;
using Data;
using Microsoft.AspNetCore.Components;
using Day2.Services;

namespace Day2.Pages.Trainees
{
    public partial class Edit
    {
		[Parameter]
		public int Id { get; set; }
		public Trainee? Trainee { get; set; }
		public bool Saved { get; set; } = false;

        [Inject]
        protected TraineeService _traineeService { get; set; }

        [Inject]
        protected TrackService _trackService { get; set; }

        public Track[] Tracks = Array.Empty<Track>();

        protected override async Task OnInitializedAsync()
		{
			Trainee = await _traineeService.GetTraineeAsync(Id);
            Tracks = await _trackService.GetTracksAsync() ?? Array.Empty<Track>();

			await base.OnInitializedAsync();
		}

        protected async Task HandleValidSubmit()
        {            
            if (Trainee == null)
            {
                return;
            }

            Saved = await _traineeService.UpdateTraineeAsync(Id, Trainee);
        }

        protected void HandleInvalidSubmit()
        {
            Saved = false;
        }
    }
}
