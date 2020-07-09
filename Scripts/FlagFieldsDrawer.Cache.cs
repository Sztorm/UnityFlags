using System;
using UnityEngine;

namespace Sztorm.Unity.Flags
{
    partial class FlagFieldsDrawer
    {
        private sealed class Cache
        {
            private readonly FlagFieldsDrawer drawer;
            public readonly bool UnderlyingEnumTypeIsSByte;
            public readonly float ToggleHeight;
            public readonly FlagFieldsAttribute FlagFields;
            public readonly FlagTooltipsAttribute FlagTooltips;
            public readonly GUIContent[] FlagsContent;

            /// <summary>
            ///     Returns <see cref="FlagFieldsAttribute"/> if such attribute is attached. Returns
            ///     <see langword="null"/> otherwise.
            /// </summary>
            /// <returns></returns>
            private FlagTooltipsAttribute GetFlagTooltipsAttribute()
            {
                object[] flagTooltipAttributes = drawer.fieldInfo.GetCustomAttributes(
                typeof(FlagTooltipsAttribute), true);
                if (flagTooltipAttributes.Length > 0)
                {
                    return (FlagTooltipsAttribute)flagTooltipAttributes[0];
                }
                return null;
            }

            /// <summary>
            ///     Returns content representing each flag. Requires <see cref="FlagFields"/> to be
            ///     initialized.
            /// </summary>
            /// <returns></returns>
            private GUIContent[] GetFlagsContent()
            {
                var result = new GUIContent[8];

                if (FlagTooltips == null)
                {
                    for (int i = 0; i < result.Length; i++)
                    {

                        result[i] = new GUIContent(FlagFields.Names[i]);
                    }
                    return result;
                }
                for (int i = 0; i < result.Length; i++)
                {
                    if (FlagTooltips.Tooltips?[i] == null)
                    {
                        result[i] = new GUIContent(FlagFields.Names[i]);
                    }
                    else
                    {
                        result[i] = new GUIContent(FlagFields.Names[i], FlagTooltips.Tooltips[i]);
                    }
                }
                return result;
            }

            public Cache(FlagFieldsDrawer drawer)
            {
                this.drawer = drawer;
                ToggleHeight = GUI.skin.toggle.padding.vertical + GUI.skin.toggle.border.vertical;
                FlagFields = drawer.attribute as FlagFieldsAttribute;
                FlagTooltips = GetFlagTooltipsAttribute();
                FlagsContent = GetFlagsContent();

                Type underlyingEnumType = Enum.GetUnderlyingType(drawer.fieldInfo.FieldType);
                UnderlyingEnumTypeIsSByte = underlyingEnumType.Name == "SByte";
            }
        }
    }
}