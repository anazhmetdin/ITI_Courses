using Data.Models;
using Data;
using Microsoft.AspNetCore.Components;

namespace Day1.Pages.Trainees
{
    public partial class Edit
    {
		[Parameter]
		public int Id { get; set; }
		public Trainee? Trainee { get; set; }
		public bool Saved { get; set; } = false;

		protected override Task OnInitializedAsync()
		{
			Trainee = Context.Trainees
                .Select(t => new Trainee() { Id = t.Id, MobileNo = t.MobileNo, Name = t.Name,
                    TrackId = t.TrackId, Birthdate = t.Birthdate, Email = t.Email, Gender
                 = t.Gender, IsGraduated = t.IsGraduated})
                .FirstOrDefault(t => t.Id == Id);

			return base.OnInitializedAsync();
		}

        protected void HandleValidSubmit()
        {            
            if (Trainee != null)
            {
                Context.Trainees.Remove(Context.Trainees.FirstOrDefault(t => t.Id == Id)!);
                Context.Trainees.Insert(Id-1, Trainee);
            }

            Saved = true;
        }

        protected void HandleInvalidSubmit()
        {
            Saved = false;
        }
    }
}
