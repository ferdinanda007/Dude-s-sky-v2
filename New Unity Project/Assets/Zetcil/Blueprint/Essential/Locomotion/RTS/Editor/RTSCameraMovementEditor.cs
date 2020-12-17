using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(RTSCameraMovement)), CanEditMultipleObjects]
    public class RTSCameraMovementEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           RTSCamera,
           ScrollSpeed,
           ScrollEdge
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            RTSCamera = serializedObject.FindProperty("RTSCamera");
            ScrollSpeed = serializedObject.FindProperty("ScrollSpeed");
            ScrollEdge = serializedObject.FindProperty("ScrollEdge");
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
                EditorGUILayout.PropertyField(ScrollSpeed, true);
                EditorGUILayout.PropertyField(ScrollEdge, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}