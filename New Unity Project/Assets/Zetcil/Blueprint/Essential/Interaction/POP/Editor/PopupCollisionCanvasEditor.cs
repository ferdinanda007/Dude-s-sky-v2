using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(PopupCollisionCanvas)), CanEditMultipleObjects]
    public class PopupCollisionCanvasEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           TargetCanvas,
           TargetCamera
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            TargetCanvas = serializedObject.FindProperty("TargetCanvas");
            TargetCamera = serializedObject.FindProperty("TargetCamera");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(TargetCanvas, true);
                if (TargetCanvas.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(TargetCamera, true);
                if (TargetCamera.objectReferenceValue == null)
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