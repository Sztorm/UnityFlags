using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Sztorm.Unity.Flags
{
    /// <summary>
    ///     Shows tooltips of 8-bit flags in Unity inspector.<br/>
    ///     To make sure tooltips are displayed, its field must be decorated with
    ///     <see cref="FlagFieldsAttribute"/> attribute.<br/>
    ///     Only tooltips that are initialized in constructor and match fields from
    ///     <see cref="FlagFieldsAttribute"/> will be displayed.
    /// </summary>
    public class FlagTooltipsAttribute : PropertyAttribute
    {
        /// <summary>
        ///     Returns flag tooltips collection. Tooltips of specified indices which are not
        ///     initialzed will be <see langword="null"/>.
        /// </summary>
        public readonly ReadOnlyCollection<string> Tooltips;

        /// <summary>
        ///     Initializes attribute with specified tooltips to be displayed in Unity inspector.
        /// </summary>
        /// <param name="tooltip0"></param>
        /// <param name="tooltip1"></param>
        /// <param name="tooltip2"></param>
        /// <param name="tooltip3"></param>
        /// <param name="tooltip4"></param>
        /// <param name="tooltip5"></param>
        /// <param name="tooltip6"></param>
        /// <param name="tooltip7"></param>
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