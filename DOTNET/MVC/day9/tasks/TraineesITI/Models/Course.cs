using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TraineesITI.Models
{
    public class Course: BaseModel
    {
        [Required]
        [MaxLength(128)]
        public string Topic { get; set; }
    }
}
