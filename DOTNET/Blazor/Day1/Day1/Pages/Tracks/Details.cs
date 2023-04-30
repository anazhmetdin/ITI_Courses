using Data;
using Data.Models;
using Microsoft.AspNetCore.Components;

namespace Day1.Pages.Tracks
{
	public partial class Details
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
	}
}
