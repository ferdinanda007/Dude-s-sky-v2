using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(SwitchController)), CanEditMultipleObjects]
    public class SwitchControllerEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            TriggerKey1,
            KeyCondition1,
            TriggerKey2,
            KeyCondition2
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");
            TriggerKey1 = serializedObject.FindProperty("TriggerKey1");
            KeyCondition1 = serializedObject.FindProperty("KeyCondition1");
            TriggerKey2 = serializedObject.FindProperty("TriggerKey2");
            KeyCondition2 = serializedObject.FindProperty("KeyCondition2");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(TriggerKey1);
                EditorGUILayout.PropertyField(KeyCondition1);
                EditorGUILayout.PropertyField(TriggerKey2);
                EditorGUILayout.PropertyField(KeyCondition2);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

}