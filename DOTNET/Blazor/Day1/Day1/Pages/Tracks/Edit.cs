using Data.Models;
using Data;
using Microsoft.AspNetCore.Components;

namespace Day1.Pages.Tracks
{
    public partial class Edit
    {
		[Parameter]
		public int Id { get; set; }
		public Track? Track { get; set; }
		public bool Saved { get; set; } = false;

		protected override Task OnInitializedAsync()
		{
			Track = Context.Tracks
                .Select(t => new Track() { Id = t.Id, Description = t.Description, Name = t.Name})
                .FirstOrDefault(t => t.Id == Id);

			return base.OnInitializedAsync();
		}

        protected void HandleValidSubmit()
        {
            var ogTrack = Context.Tracks
                .FirstOrDefault(t => t.Id == Id);
            
            if (ogTrack != null && Track != null)
            {
                ogTrack.Name = Track.Name;
                ogTrack.Description = Track.Description;
            }

            Saved = true;
        }

        protected void HandleInvalidSubmit()
        {
            Saved = false;
        }
    }
}
