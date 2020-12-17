using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(PTCController)), CanEditMultipleObjects]
    public class PTCControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           PTCCamera,
           Destination,
           speed,
           maxReach
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            PTCCamera = serializedObject.FindProperty("PTCCamera");
            Destination = serializedObject.FindProperty("Destination");
            speed = serializedObject.FindProperty("speed");
            maxReach = serializedObject.FindProperty("maxReach");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(PTCCamera, true);
                if (PTCCamera.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(Destination, true);
                if (Destination.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(speed, true);
                EditorGUILayout.PropertyField(maxReach, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}