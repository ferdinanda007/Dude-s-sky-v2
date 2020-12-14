using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(UIToggle)), CanEditMultipleObjects]
    public class UIToggleEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            usingToggleOn,
            ToggleOnEvent,
            usingToggleOff,
            ToggleOffEvent,
            usingToggleGroup,
            ToggleType,
            ToggleObject
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");

            usingToggleOn = serializedObject.FindProperty("usingToggleOn");
            ToggleOnEvent = serializedObject.FindProperty("ToggleOnEvent");
            usingToggleOff = serializedObject.FindProperty("usingToggleOff");
            ToggleOffEvent = serializedObject.FindProperty("ToggleOffEvent");

            usingToggleGroup = serializedObject.FindProperty("usingToggleGroup");
            ToggleType = serializedObject.FindProperty("ToggleType");
            ToggleObject = serializedObject.FindProperty("ToggleObject");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(usingToggleOn, true);
                if (usingToggleOn.boolValue)
                {
                    EditorGUILayout.PropertyField(ToggleOnEvent);
                }

                EditorGUILayout.PropertyField(usingToggleOff, true);
                if (usingToggleOff.boolValue)
                {
                    EditorGUILayout.PropertyField(ToggleOffEvent);
                }

                EditorGUILayout.PropertyField(usingToggleGroup, true);
                if (usingToggleGroup.boolValue)
                {
                    EditorGUILayout.PropertyField(ToggleType);
                    EditorGUILayout.PropertyField(ToggleObject, true);
                }
                
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

}