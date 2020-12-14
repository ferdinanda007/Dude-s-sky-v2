using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(SunController)), CanEditMultipleObjects]
    public class SunControllerEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            DirectLight,
            RotateDirection,
            RotateDelay,
            usingKeyboard,
            TriggerForwardKey,
            TriggerBackwardKey,
            Speed,
            TimeElapsed
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");
            DirectLight = serializedObject.FindProperty("DirectLight");
            RotateDirection = serializedObject.FindProperty("RotateDirection");
            RotateDelay = serializedObject.FindProperty("RotateDelay");
            usingKeyboard = serializedObject.FindProperty("usingKeyboard");
            TriggerForwardKey = serializedObject.FindProperty("TriggerForwardKey");
            TriggerBackwardKey = serializedObject.FindProperty("TriggerBackwardKey");
            Speed = serializedObject.FindProperty("Speed");
            TimeElapsed = serializedObject.FindProperty("TimeElapsed");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(DirectLight);
                EditorGUILayout.PropertyField(RotateDirection);
                EditorGUILayout.PropertyField(RotateDelay);

                EditorGUILayout.PropertyField(usingKeyboard);

                bool check1 = usingKeyboard.boolValue;

                if (check1)
                {
                    EditorGUILayout.PropertyField(TriggerForwardKey);
                    EditorGUILayout.PropertyField(TriggerBackwardKey);
                    EditorGUILayout.PropertyField(Speed);
                }
                
                EditorGUILayout.PropertyField(TimeElapsed);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

}