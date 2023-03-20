using TraineesITI.Data;
using TraineesITI.Models;

namespace TraineesITI.Repositories.Tracks
{
    public class TracksRepo : ModelRepo<Track>
    {
        public TracksRepo(Context context) : base(context) { }
    }
}
