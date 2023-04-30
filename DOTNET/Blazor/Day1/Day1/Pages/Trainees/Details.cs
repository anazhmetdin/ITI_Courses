using Data;
using Data.Models;
using Microsoft.AspNetCore.Components;

namespace Day1.Pages.Trainees
{
	public partial class Details
	{
		[Parameter]
		public int Id { get; set; }
		public Trainee? Trainee { get; set; }
		public Track? Track { get; set; }

		protected override Task OnInitializedAsync()
		{
			Trainee = Context.Trainees.FirstOrDefault(t => t.Id == Id);
			Track = Context.Tracks.FirstOrDefault(t => t.Id == Trainee?.TrackId);
			return base.OnInitializedAsync();
		}
	}
}
