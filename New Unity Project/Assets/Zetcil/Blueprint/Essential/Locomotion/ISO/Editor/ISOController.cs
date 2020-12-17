using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(ISOController)), CanEditMultipleObjects]
    public class ISOControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           speed
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            speed = serializedObject.FindProperty("speed");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(speed, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}