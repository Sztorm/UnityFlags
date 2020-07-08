using UnityEngine;

namespace Sztorm.Unity.Flags
{
    public class FlagFieldsAttribute : PropertyAttribute
    {
        public readonly string[] Names;
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
            Names = new string[8];
            Names[0] = flagName0;
            Names[1] = flagName1;
            Names[2] = flagName2;
            Names[3] = flagName3;
            Names[4] = flagName4;
            Names[5] = flagName5;
            Names[6] = flagName6;
            Names[7] = flagName7;

            int count = 0;

            for (int i = 0; i < Names.Length; i++)
            {
                if (Names[i] != null)
                {
                    count++;
                }
            }
            Count = count;
        }
    }
}