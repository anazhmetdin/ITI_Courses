using Data.Models;
using Day2.Services;
using Microsoft.AspNetCore.Components;

namespace Day2.Pages.Trainees
{
    public partial class Create
    {
        public Trainee Trainee { get; set; } = new Trainee() { Birthdate = DateTime.UtcNow };
        public bool Saved { get; set; } = false;

        [Inject]
        protected TrackService _trackService { get; set; }

        public Track[] Tracks = Array.Empty<Track>();

        [Inject]
        protected TraineeService _TraineeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Tracks = await _trackService.GetTracksAsync() ?? Array.Empty<Track>();
            await base.OnInitializedAsync();
        }

        public async Task CreateTrainee()
        {
            Saved = await _TraineeService.AddTraineeAsync(Trainee);
        }
    }
}
