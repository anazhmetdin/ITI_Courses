using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TraineesITI.Models
{
    public class Track : BaseModel
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        [MaxLength(256)]
        public string Description { get; set; }
    }
}
