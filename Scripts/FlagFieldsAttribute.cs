using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Sztorm.Unity.Flags
{
    /// <summary>
    ///     Shows 8-bit enum as set of flags in Unity inspector.<br/>
    ///     To make sure flags are displayed, its field must be <see langword="public"/> or be
    ///     decorated with <see cref="SerializeField"/> attribute.<br/>
    ///     Also field must be an enum with underlying type of <see cref="byte"/> or
    ///     <see cref="sbyte"/> and have properly initialized fields.<br/>
    ///     Only flags that are initialized in constructor will be displayed.
    /// </summary>
    public class FlagFieldsAttribute : PropertyAttribute
    {
        /// <summary>
        ///     Returns flag names collection. Names of specified indices of flags which are not
        ///     initialzed will be <see langword="null"/>.
        /// </summary>
        public readonly ReadOnlyCollection<string> Names;

        /// <summary>
        ///     Returns count of initialized flags.
        /// </summary>
        public readonly int Count;

        /// <summary>
        ///     Initializes attribute with specified flag fields to be displayed in Unity
        ///     inspector.
        /// </summary>
        /// <param name="flagName0"></param>
        /// <param name="flagName1"></param>
        /// <param name="flagName2"></param>
        /// <param name="flagName3"></param>
        /// <param name="flagName4"></param>
        /// <param name="flagName5"></param>
        /// <param name="flagName6"></param>
        /// <param name="flagName7"></param>
        public FlagFieldsAttribute(
            string flagName0 = null,
            string flagName1 = null,
            string flagName2 = null,
            string flagName3 = null,
            string flagName4 = null,
            string flagName5 = null,
            string flagName6 = null,
            string flagName7 = null)
        {
            var names = new string[8];
            names[0] = flagName0;
            names[1] = flagName1;
            names[2] = flagName2;
            names[3] = flagName3;
            names[4] = flagName4;
            names[5] = flagName5;
            names[6] = flagName6;
            names[7] = flagName7;
            int count = 0;

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] != null)
                {
                    count++;
                }
            }
            Names = Array.AsReadOnly(names);
            Count = count;
        }
    }
}