using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(NPCController)), CanEditMultipleObjects]
    public class NPCControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           ClockTimer,
           EventType,
           TargetAnimator,
           NPCSetting
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            ClockTimer = serializedObject.FindProperty("ClockTimer");
            EventType = serializedObject.FindProperty("EventType");
            TargetAnimator = serializedObject.FindProperty("TargetAnimator");
            NPCSetting = serializedObject.FindProperty("NPCSetting");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(EventType, true);
                EditorGUILayout.PropertyField(TargetAnimator, true);
                if (TargetAnimator.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(NPCSetting, true);
                EditorGUILayout.PropertyField(ClockTimer, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}