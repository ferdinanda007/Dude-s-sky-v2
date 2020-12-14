using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(AutolookController)), CanEditMultipleObjects]
    public class AutolookControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           TargetObject,
           usingAutolook,
           MinimalRange,
           TargetTag
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            TargetObject = serializedObject.FindProperty("TargetObject");
            usingAutolook = serializedObject.FindProperty("usingAutolook");
            MinimalRange = serializedObject.FindProperty("MinimalRange");
            TargetTag = serializedObject.FindProperty("TargetTag");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(TargetObject, true);
                if (TargetObject.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(usingAutolook, true);
                if (usingAutolook.boolValue)
                {
                    EditorGUILayout.PropertyField(MinimalRange, true);
                    EditorGUILayout.PropertyField(TargetTag, true);
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