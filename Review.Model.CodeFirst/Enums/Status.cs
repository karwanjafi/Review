using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review.Model.Enums
{
    [Flags]
    public enum Status
    {
        Active = 1,
        Hold = 2,
        Blocked = 3,
        NotActived = 4,
        DeActive = 5,
        Expired = 6,


    }
}
