using Data.Models;
using Data;
using Microsoft.AspNetCore.Components;
using Day2.Services;

namespace Day2.Pages.Tracks
{
    public partial class Delete
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

        public async Task ConfirmDelete()
        {
            if (await _trackService.DeleteTrackAsync(Id))
            {
                Track = null;
            }

        }
    }
}
