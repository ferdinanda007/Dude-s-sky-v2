using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(VarKey)), CanEditMultipleObjects]
    public class VarKeyEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           InputKeyDown,
           KeyDownEvent,
           InputKey,
           KeyEvent,
           InputKeyUp,
           KeyUpEvent
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            InputKeyDown = serializedObject.FindProperty("InputKeyDown");
            KeyDownEvent = serializedObject.FindProperty("KeyDownEvent");
            InputKey = serializedObject.FindProperty("InputKey");
            KeyEvent = serializedObject.FindProperty("KeyEvent");
            InputKeyUp = serializedObject.FindProperty("InputKeyUp");
            KeyUpEvent = serializedObject.FindProperty("KeyUpEvent");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(InputKeyDown);
                EditorGUILayout.PropertyField(KeyDownEvent);
                EditorGUILayout.PropertyField(InputKey);
                EditorGUILayout.PropertyField(KeyEvent);
                EditorGUILayout.PropertyField(InputKeyUp);
                EditorGUILayout.PropertyField(KeyUpEvent);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}