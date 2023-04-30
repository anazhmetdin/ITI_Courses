using Data.Models;
using Data;
using Microsoft.AspNetCore.Components;
using Day2.Services;

namespace Day2.Pages.Trainees
{
    public partial class Delete
    {
        [Parameter]
        public int Id { get; set; }
        public Trainee? Trainee { get; set; }

        [Inject]
        protected TraineeService TraineeService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Trainee = await TraineeService.GetTraineeAsync(Id);
            await base.OnInitializedAsync();
        }

        public async Task ConfirmDelete()
        {
            if (Trainee == null) return;

            if (await TraineeService.DeleteTraineeAsync(Id))
                Trainee = null;
        }
    }
}
