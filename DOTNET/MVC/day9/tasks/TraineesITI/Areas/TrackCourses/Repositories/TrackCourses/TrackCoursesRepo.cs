using TraineesITI.Areas.TrackCourses.Models;
using TraineesITI.Data;
using TraineesITI.Models;

namespace TraineesITI.Repositories.Courses
{
    public class TrackCoursesRepo : ModelRepo<TrackCourse>
    {
        public TrackCoursesRepo(Context context) : base(context) { }
    }
}
