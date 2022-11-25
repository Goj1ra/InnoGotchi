using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchi.Core.Enums
{
    public enum ThirstyLevel
    {
        Full,
        Normal,
        Thirsty,
        [NonSerialized]
        Dead
    }
}
