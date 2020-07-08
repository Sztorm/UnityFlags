using System;
using UnityEngine;
using UnityEditor;
using Sztorm.Extensions.Enum;

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

    [CustomPropertyDrawer(typeof(FlagFieldsAttribute))]
    internal class FlagsFieldsDrawer : PropertyDrawer
    {
        private const float ToggleControlHeight = 18;
        private const float InspectorBottomPadding = 2;

        private bool isCached = false;
        private bool underlyingEnumTypeIsSByte;
        private float toggleHeight;
        private FlagFieldsAttribute flagFields;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!isCached)
            {
                flagFields = attribute as FlagFieldsAttribute;
            }
            return ToggleControlHeight * flagFields.Count - InspectorBottomPadding;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!isCached)
            {
                toggleHeight = GUI.skin.toggle.padding.vertical + GUI.skin.toggle.border.vertical;
                flagFields = attribute as FlagFieldsAttribute;
                Type underlyingEnumType = Enum.GetUnderlyingType(fieldInfo.FieldType);
                underlyingEnumTypeIsSByte = underlyingEnumType.Name == "SByte";
                isCached = true;
            }
            BitFlags8 flags = (BitFlags8)(property.intValue);
            Vector2 toggleRectSize = new Vector2(position.size.x, toggleHeight);

            EditorGUI.BeginProperty(position, label, property);

            for (int i = 0, propIndex = 0, length = flagFields.Names.Length; i < length; i++)
            {
                if (flagFields.Names[i] != null)
                {
                    BitFlags8 flag = (BitFlags8)(1 << i);

                    bool isChecked = EditorGUI.Toggle(
                        new Rect(
                            new Vector2(position.x, position.y + ToggleControlHeight * propIndex),
                            toggleRectSize),
                        flagFields.Names[i],
                        flags.HasAllFlags(flag));

                    flags = flags.WithFlagsSetTo(flag, isChecked);
                    propIndex++;
                }
            }
            if (underlyingEnumTypeIsSByte)
            {
                property.intValue = (sbyte)flags;
            }
            else
            {
                property.intValue = (byte)flags;
            }
            EditorGUI.EndProperty();
        }
    }
}