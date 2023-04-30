using Data;
using Data.Models;
using Day2.Services;
using Microsoft.AspNetCore.Components;

namespace Day2.Pages.Trainees
{
	public partial class Details
	{
		[Parameter]
		public int Id { get; set; }
		public Trainee? Trainee { get; set; }
		public Track? Track { get; set; }

        [Inject]
        protected TraineeService _traineeService { get; set; }

        protected override async Task OnInitializedAsync()
		{
			Trainee = await _traineeService.GetTraineeAsync(Id);
			await base.OnInitializedAsync();
		}
	}
}
