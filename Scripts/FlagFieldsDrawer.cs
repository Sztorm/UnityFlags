using System;
using UnityEngine;
using UnityEditor;
using Sztorm.Extensions.Enum;

namespace Sztorm.Unity.Flags
{
    [CustomPropertyDrawer(typeof(FlagFieldsAttribute))]
    internal sealed partial class FlagFieldsDrawer : PropertyDrawer
    {
        private const float ToggleControlHeight = 18;
        private const float InspectorBottomPadding = 2;
        private Cache cache;
        private Action<SerializedProperty, BitFlags32> setPropertyValue;

        private void SetPropertyByteValue(SerializedProperty property, BitFlags32 flags)
        {
            property.intValue = (byte)flags;
        }

        private void SetPropertySByteValue(
            SerializedProperty property, BitFlags32 flags)
        {
            property.intValue = (sbyte)flags;
        }

        private void SetProperSetPropertyValueMethod()
        {
            Type underlyingEnumType = Enum.GetUnderlyingType(fieldInfo.FieldType);

            if (underlyingEnumType.Equals(typeof(sbyte)))
            {
                setPropertyValue = SetPropertySByteValue;
            }
            else if (underlyingEnumType.Equals(typeof(byte)))
            {
                setPropertyValue = SetPropertyByteValue;
            }
        }

        private void InitDrawerFieldsIfNeeded()
        {
            if (cache is null)
            {
                cache = new Cache(this);
                SetProperSetPropertyValueMethod();
            }
        }

        private void CheckFlagsTypeCompatibility()
        {
            if (cache.IsIncompatibleType)
            {
                throw new ArgumentException("Enum underlying type must be byte or sbyte. Do not " +
                    "use FlagFields attribute with other enum types. Fix fields that have wrong " +
                    $"enum type in {fieldInfo.DeclaringType} script or remove the FlagFields " +
                    $"attribute from them.");
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            InitDrawerFieldsIfNeeded();
            CheckFlagsTypeCompatibility();
            return ToggleControlHeight * cache.FlagFields.Count - InspectorBottomPadding;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            InitDrawerFieldsIfNeeded();
            CheckFlagsTypeCompatibility();
            BitFlags32 flags = (BitFlags32)((byte)property.intValue);

            Vector2 toggleRectSize = new Vector2(position.size.x, cache.ToggleHeight);

            EditorGUI.BeginProperty(position, label, property);

            for (int i = 0, propIndex = 0, length = cache.FlagFields.Names.Count; i < length; i++)
            {
                if (cache.FlagFields.Names[i] != null)
                {
                    BitFlags32 flag = (BitFlags32)(1 << i);

                    bool isChecked = EditorGUI.Toggle(
                        new Rect(
                            new Vector2(position.x, position.y + ToggleControlHeight * propIndex),
                            toggleRectSize),
                        cache.FlagsContent[i],
                        flags.HasAllFlags(flag));
                    flags = flags.WithFlagsSetTo(flag, isChecked);
                    propIndex++;
                }
            }
            setPropertyValue(property, flags);

            EditorGUI.EndProperty();
        }
    }
}