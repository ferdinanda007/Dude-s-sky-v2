using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(TDSCameraFollow)), CanEditMultipleObjects]
    public class TDSCameraFollowEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           CameraController
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            CameraController = serializedObject.FindProperty("CameraController");
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
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}