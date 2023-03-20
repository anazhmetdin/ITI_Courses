using System.ComponentModel.DataAnnotations;
using TraineesITI.Areas.TrackCourses.Models;
using TraineesITI.Models;

namespace TraineesITI.Areas.TraineeCourses.Models
{
    public class TraineeCourse: BaseModel
    {
        public int TraineeId { get; set; }
        public virtual Trainee Trainee { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        [Range(0,100)]
        public int Grade { get; set; }
    }
}
