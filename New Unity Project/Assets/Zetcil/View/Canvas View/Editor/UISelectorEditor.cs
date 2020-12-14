using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(UISelector)), CanEditMultipleObjects]
    public class UISelectorEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           TargetSelector,
           SelectorStatus
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            TargetSelector = serializedObject.FindProperty("TargetSelector");
            SelectorStatus = serializedObject.FindProperty("SelectorStatus");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(TargetSelector, true);
                if (TargetSelector.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(SelectorStatus, true);
                if (SelectorStatus.objectReferenceValue == null)
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