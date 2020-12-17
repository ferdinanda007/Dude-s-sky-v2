using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(FPSMouseLook)), CanEditMultipleObjects]
    public class FPSMouseLookEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           TargetCamera,
           lookAutomatic,
           MouseKey,
           CursorLocked,
           CursorVisible,
           speedHorizontal,
           speedVertical
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            TargetCamera = serializedObject.FindProperty("TargetCamera");
            lookAutomatic = serializedObject.FindProperty("lookAutomatic");
            MouseKey = serializedObject.FindProperty("MouseKey");
            CursorLocked = serializedObject.FindProperty("CursorLocked");
            CursorVisible = serializedObject.FindProperty("CursorVisible");
            speedHorizontal = serializedObject.FindProperty("speedHorizontal");
            speedVertical = serializedObject.FindProperty("speedVertical");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(TargetCamera, true);
                if (TargetCamera.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(CursorLocked, true);
                EditorGUILayout.PropertyField(CursorVisible, true);
                EditorGUILayout.PropertyField(lookAutomatic, true);
                if (!lookAutomatic.boolValue)
                {
                    EditorGUILayout.PropertyField(MouseKey, true);
                }

                EditorGUILayout.PropertyField(speedHorizontal, true);
                EditorGUILayout.PropertyField(speedVertical, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}