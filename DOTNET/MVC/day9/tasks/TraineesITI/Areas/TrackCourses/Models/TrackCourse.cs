using TraineesITI.Models;

namespace TraineesITI.Areas.TrackCourses.Models
{
    public class TrackCourse: BaseModel
    {
        public int TrackId { get; set; }
        public virtual Track Track { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
