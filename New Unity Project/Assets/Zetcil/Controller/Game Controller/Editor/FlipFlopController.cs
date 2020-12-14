using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(FlipFlopController)), CanEditMultipleObjects]
    public class FlipFlopControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           Interval,
           usingFlipEvent,
           FlipEvent,
           usingFlopEvent,
           FlopEvent,
           currentClock
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            Interval = serializedObject.FindProperty("Interval");
            usingFlipEvent = serializedObject.FindProperty("usingFlipEvent");
            FlipEvent = serializedObject.FindProperty("FlipEvent");
            usingFlopEvent = serializedObject.FindProperty("usingFlopEvent");
            FlopEvent = serializedObject.FindProperty("FlopEvent");
            currentClock = serializedObject.FindProperty("currentClock");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(Interval, true);
                EditorGUILayout.PropertyField(usingFlipEvent, true);
                if (usingFlipEvent.boolValue)
                {
                    EditorGUILayout.PropertyField(FlipEvent, true);
                }
                EditorGUILayout.PropertyField(usingFlopEvent, true);
                if (usingFlopEvent.boolValue)
                {
                    EditorGUILayout.PropertyField(FlopEvent, true);
                }
                EditorGUILayout.PropertyField(currentClock, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}