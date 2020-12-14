using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(UIList)), CanEditMultipleObjects]
    public class UIListEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           TargetText,
           ListVariables,
           PrefixText,
           PostfixText
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            TargetText = serializedObject.FindProperty("TargetText");
            ListVariables = serializedObject.FindProperty("ListVariables");
            PrefixText = serializedObject.FindProperty("PrefixText");
            PostfixText = serializedObject.FindProperty("PostfixText");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(TargetText, true);
                if (TargetText.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(ListVariables, true);
                if (ListVariables.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(PrefixText, true);
                EditorGUILayout.PropertyField(PostfixText, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}