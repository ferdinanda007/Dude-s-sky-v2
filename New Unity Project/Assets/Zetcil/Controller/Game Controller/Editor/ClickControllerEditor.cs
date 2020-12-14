using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(ClickController)), CanEditMultipleObjects]
    public class ClickControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           usingTrueClickEvent,
           TrueClickEvent,
           usingFalseClickEvent,
           FalseClickEvent,
           ClickStatus
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            usingTrueClickEvent = serializedObject.FindProperty("usingTrueClickEvent");
            TrueClickEvent = serializedObject.FindProperty("TrueClickEvent");
            usingFalseClickEvent = serializedObject.FindProperty("usingFalseClickEvent");
            FalseClickEvent = serializedObject.FindProperty("FalseClickEvent");
            ClickStatus = serializedObject.FindProperty("ClickStatus");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(usingTrueClickEvent, true);
                if (usingTrueClickEvent.boolValue)
                {
                    EditorGUILayout.PropertyField(TrueClickEvent, true);
                }
                EditorGUILayout.PropertyField(usingFalseClickEvent, true);
                if (usingFalseClickEvent.boolValue)
                {
                    EditorGUILayout.PropertyField(FalseClickEvent, true);
                }
                EditorGUILayout.PropertyField(ClickStatus, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}