using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(ADVCameraOrbit)), CanEditMultipleObjects]
    public class ADVCameraOrbitEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           CameraController,
           turnSpeed,
           offset
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            CameraController = serializedObject.FindProperty("CameraController");
            turnSpeed = serializedObject.FindProperty("turnSpeed");
            offset = serializedObject.FindProperty("offset");
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
                EditorGUILayout.PropertyField(turnSpeed, true);
                EditorGUILayout.PropertyField(offset, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}