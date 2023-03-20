using TraineesITI.Data;
using TraineesITI.Models;

namespace TraineesITI.Repositories.Courses
{
    public class CoursesRepo : ModelRepo<Course>
    {
        public CoursesRepo(Context context) : base(context) { }
    }
}
