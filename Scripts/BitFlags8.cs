using System;

namespace Sztorm.Unity.Flags
{
    [Flags]
    internal enum BitFlags8 : int
    {
        None = 0,
        Bit1 = 1,
        Bit2 = 2,
        Bit3 = 4,
        Bit4 = 8,
        Bit5 = 16,
        Bit6 = 32,
        Bit7 = 64,
        Bit8 = -128,
    }
}
