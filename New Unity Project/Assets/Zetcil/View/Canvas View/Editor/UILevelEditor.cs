using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(UILevel)), CanEditMultipleObjects]
    public class UILevelEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           DefaultLevelIndex,
           LevelName,
           TargetLevel,
           usingIndex,
           VarIndex
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            DefaultLevelIndex = serializedObject.FindProperty("DefaultLevelIndex");
            LevelName = serializedObject.FindProperty("LevelName");
            TargetLevel = serializedObject.FindProperty("TargetLevel");
            usingIndex = serializedObject.FindProperty("usingIndex");
            VarIndex = serializedObject.FindProperty("VarIndex");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(DefaultLevelIndex, true);
                EditorGUILayout.PropertyField(LevelName, true);
                if (LevelName.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(TargetLevel, true);
                EditorGUILayout.PropertyField(usingIndex, true);
                if (usingIndex.boolValue)
                {
                    EditorGUILayout.PropertyField(VarIndex, true);
                    if (VarIndex.objectReferenceValue == null)
                    {
                        EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                    }
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