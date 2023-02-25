using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    [Flags]
    public enum EntityState
    {
        Added = 2, Changed = 4, UnChanged = 8, Deleted = 16
    }
}
