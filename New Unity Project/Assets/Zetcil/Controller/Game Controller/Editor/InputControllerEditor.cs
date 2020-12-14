using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(InputController)), CanEditMultipleObjects]
    public class InputControllerEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            KeyboardInput
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");
            KeyboardInput = serializedObject.FindProperty("KeyboardInput");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(KeyboardInput, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

}