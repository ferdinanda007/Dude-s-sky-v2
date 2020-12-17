using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(PTCCameraFollow)), CanEditMultipleObjects]
    public class PTCCameraFollowEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           CameraController,
           distance,
           height,
           heightDamping
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            CameraController = serializedObject.FindProperty("CameraController");
            distance = serializedObject.FindProperty("distance");
            height = serializedObject.FindProperty("height");
            heightDamping = serializedObject.FindProperty("heightDamping");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(CameraController, true);
                if (CameraController.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(distance, true);
                EditorGUILayout.PropertyField(height, true);
                EditorGUILayout.PropertyField(heightDamping, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}