using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Sztorm.Unity.Flags
{
    public class FlagFieldsAttribute : PropertyAttribute
    {
        public readonly ReadOnlyCollection<string> Names;
        public readonly int Count;

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