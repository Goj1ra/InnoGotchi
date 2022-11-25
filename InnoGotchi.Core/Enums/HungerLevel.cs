using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoGotchi.Core.Enums
{
    public enum HungerLevel
    {
        Full,
        Normal,
        Hunger,
        [NonSerialized]
        Dead
    }
}
