using TraineesITI.Areas.TraineeCourses.Models;
using TraineesITI.Data;
using TraineesITI.Models;

namespace TraineesITI.Repositories.Courses
{
    public class TraineeCoursesRepo : ModelRepo<TraineeCourse>
    {
        public TraineeCoursesRepo(Context context) : base(context) { }
    }
}
