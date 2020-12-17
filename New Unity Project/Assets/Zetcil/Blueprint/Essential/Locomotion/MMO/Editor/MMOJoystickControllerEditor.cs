using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(MMOJoystickController)), CanEditMultipleObjects]
    public class MMOJoystickControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           joystickMode,
           vectorMode,
           pressedColor,
           deadZone,
           clampZone,
           directions,
           simmetryAngle
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            joystickMode = serializedObject.FindProperty("joystickMode");
            vectorMode = serializedObject.FindProperty("vectorMode");
            pressedColor = serializedObject.FindProperty("pressedColor");
            deadZone = serializedObject.FindProperty("deadZone");
            clampZone = serializedObject.FindProperty("clampZone");
            directions = serializedObject.FindProperty("directions");
            simmetryAngle = serializedObject.FindProperty("simmetryAngle");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(joystickMode, true);
                EditorGUILayout.PropertyField(vectorMode, true);
                EditorGUILayout.PropertyField(pressedColor, true);
                EditorGUILayout.PropertyField(deadZone, true);
                EditorGUILayout.PropertyField(clampZone, true);
                EditorGUILayout.PropertyField(directions, true);
                EditorGUILayout.PropertyField(simmetryAngle, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}