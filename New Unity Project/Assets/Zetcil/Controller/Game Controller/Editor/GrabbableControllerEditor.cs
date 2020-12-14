using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(GrabbableController)), CanEditMultipleObjects]
    public class GrabbableControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           RotationType,
           TargetObject,
           TargetCamera,
           RotationSpeed
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            RotationType = serializedObject.FindProperty("RotationType");
            TargetObject = serializedObject.FindProperty("TargetObject");
            TargetCamera = serializedObject.FindProperty("TargetCamera");
            RotationSpeed = serializedObject.FindProperty("RotationSpeed");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(RotationType, true);
                EditorGUILayout.PropertyField(TargetObject, true);
                if (TargetObject.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(TargetCamera, true);
                if (TargetCamera.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(RotationSpeed, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}