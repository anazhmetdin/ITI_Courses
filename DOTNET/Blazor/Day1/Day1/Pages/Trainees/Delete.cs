using Data.Models;
using Data;
using Microsoft.AspNetCore.Components;

namespace Day1.Pages.Trainees
{
    public partial class Delete
    {
        [Parameter]
        public int Id { get; set; }
        public Trainee? Trainee { get; set; }

        protected override Task OnInitializedAsync()
        {
            Trainee = Context.Trainees.FirstOrDefault(t => t.Id == Id);
            return base.OnInitializedAsync();
        }

        public void ConfirmDelete()
        {
            if (Trainee == null) return;

            Context.Trainees.Remove(Trainee);

            Trainee = null;
        }
    }
}
