using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(RSCCameraFollow)), CanEditMultipleObjects]
    public class RSCCameraFollowEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           CameraController,
           shouldRotate,
           distance,
           height,
           heightDamping,
           rotationDamping
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            CameraController = serializedObject.FindProperty("CameraController");
            shouldRotate = serializedObject.FindProperty("shouldRotate");
            distance = serializedObject.FindProperty("distance");
            height = serializedObject.FindProperty("height");
            heightDamping = serializedObject.FindProperty("heightDamping");
            rotationDamping = serializedObject.FindProperty("rotationDamping");
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
                EditorGUILayout.PropertyField(shouldRotate, true);
                EditorGUILayout.PropertyField(distance, true);
                EditorGUILayout.PropertyField(height, true);
                EditorGUILayout.PropertyField(heightDamping, true);
                EditorGUILayout.PropertyField(rotationDamping, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}