using TraineesITI.Data;
using TraineesITI.Models;

namespace TraineesITI.Repositories.Trainees
{
    public class TraineesRepo : ModelRepo<Trainee>
    {
        public TraineesRepo(Context context) : base(context) { }
    }
}
