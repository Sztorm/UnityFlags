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
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (cache is null)
            {
                cache = new Cache(this);
            }
            return ToggleControlHeight * cache.FlagFields.Count - InspectorBottomPadding;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (cache is null)
            {
                cache = new Cache(this);
            }
            BitFlags8 flags = (BitFlags8)(property.intValue);
            Vector2 toggleRectSize = new Vector2(position.size.x, cache.ToggleHeight);

            EditorGUI.BeginProperty(position, label, property);

            for (int i = 0, propIndex = 0, length = cache.FlagFields.Names.Count; i < length; i++)
            {
                if (cache.FlagFields.Names[i] != null)
                {
                    BitFlags8 flag = (BitFlags8)(1 << i);

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
            if (cache.UnderlyingEnumTypeIsSByte)
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