using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(RTSController)), CanEditMultipleObjects]
    public class RTSControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           RTSCamera,
           Selection,
           Destination,
           PlayerTag,
           speed,
           maxReach
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            RTSCamera = serializedObject.FindProperty("RTSCamera");
            Selection = serializedObject.FindProperty("Selection");
            Destination = serializedObject.FindProperty("Destination");
            PlayerTag = serializedObject.FindProperty("PlayerTag");
            speed = serializedObject.FindProperty("speed");
            maxReach = serializedObject.FindProperty("maxReach");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(RTSCamera, true);
                if (RTSCamera.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(Selection, true);
                if (Selection.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(Destination, true);
                if (Destination.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(PlayerTag, true);
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