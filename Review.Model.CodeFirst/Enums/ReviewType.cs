namespace Review.Model.CodeFirst.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Flags]
    public enum ReviewType
    {
        Negetive = 0,
        Positive = 1,
        Neutral = 2
    }
}
