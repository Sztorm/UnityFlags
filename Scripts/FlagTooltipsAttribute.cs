using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Sztorm.Unity.Flags
{
    public class FlagTooltipsAttribute : PropertyAttribute
    {
        public readonly ReadOnlyCollection<string> Tooltips;

        public FlagTooltipsAttribute(
            string tooltip0 = null,
            string tooltip1 = null,
            string tooltip2 = null,
            string tooltip3 = null,
            string tooltip4 = null,
            string tooltip5 = null,
            string tooltip6 = null,
            string tooltip7 = null)
        {
            var tooltips = new string[8];
            tooltips[0] = tooltip0;
            tooltips[1] = tooltip1;
            tooltips[2] = tooltip2;
            tooltips[3] = tooltip3;
            tooltips[4] = tooltip4;
            tooltips[5] = tooltip5;
            tooltips[6] = tooltip6;
            tooltips[7] = tooltip7;
            Tooltips = Array.AsReadOnly(tooltips);
        }
    }
}