using Microsoft.AspNetCore.Identity;

namespace IdentityPractice.Models
{
    public class Employee: IdentityUser
    {
        public DateTime HiringDate { get; set; }
    }
}
