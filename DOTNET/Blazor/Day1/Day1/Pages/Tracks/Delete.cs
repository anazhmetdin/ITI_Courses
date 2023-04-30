using Data.Models;
using Data;
using Microsoft.AspNetCore.Components;

namespace Day1.Pages.Tracks
{
    public partial class Delete
    {
        [Parameter]
        public int Id { get; set; }
        public Track? Track { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();

        protected override Task OnInitializedAsync()
        {
            Track = Context.Tracks.FirstOrDefault(t => t.Id == Id);
            Trainees = Context.Trainees.Where(t => t.TrackId == Id).ToList();
            return base.OnInitializedAsync();
        }

        public void ConfirmDelete()
        {
            if (Track == null) return;

            Context.Tracks.Remove(Track);
            foreach (var trinee in Trainees)
            {
                trinee.TrackId = -1;
            }

            Track = null;
        }
    }
}
