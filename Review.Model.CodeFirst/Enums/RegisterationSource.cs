namespace Review.Model.CodeFirst.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Flags]
    public enum RegisterationSource
    {
        Facebook = 1,
        Google = 2,
        SiteRegisteration = 3
    }
}
