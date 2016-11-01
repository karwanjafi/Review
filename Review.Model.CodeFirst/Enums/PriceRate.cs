using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review.Model.CodeFirst.Enums
{
    [Flags]
    public enum PriceRate
    {
        VeryCheap = 1,
        Cheap = 2,
        Normal = 3,
        Expensive = 4,
        VeryExpensive = 5,
        Luxary = 6,
    }
}
