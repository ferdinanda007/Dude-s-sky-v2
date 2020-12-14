using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(FadeController)), CanEditMultipleObjects]
    public class FadeEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            usingFadeIn,
            FadeInSettings,
            usingFadeOut,
            FadeOutSettings
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");
            usingFadeIn = serializedObject.FindProperty("usingFadeIn");
            FadeInSettings = serializedObject.FindProperty("FadeInSettings");
            usingFadeOut = serializedObject.FindProperty("usingFadeOut");
            FadeOutSettings = serializedObject.FindProperty("FadeOutSettings");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(usingFadeIn, true);
                if (usingFadeIn.boolValue)
                {
                    EditorGUILayout.PropertyField(FadeInSettings, true);
                }
                EditorGUILayout.PropertyField(usingFadeOut, true);
                if (usingFadeOut.boolValue)
                {
                    EditorGUILayout.PropertyField(FadeOutSettings, true);
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