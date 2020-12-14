using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(SingletonController)), CanEditMultipleObjects]
    public class SingletonControllerEditor : Editor
    {
        public SerializedProperty
           isEnabled
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.HelpBox("Singleton Activated", MessageType.Info);
            }
            else
            {
                EditorGUILayout.HelpBox("Prefab Status: Disabled", MessageType.Error);
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}