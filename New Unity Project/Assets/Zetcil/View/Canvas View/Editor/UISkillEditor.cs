using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(UISkill)), CanEditMultipleObjects]
    public class UISkillEditor : Editor
    {
        public SerializedProperty
           isEnabled,
           ActionStatus,
           SkillButton,
           usingShortcut,
           Shortcut,
           usingCooldown,
           CooldownTimer,
           CooldownText,
           usingMana,
           TargetMana,
           ManaCost
        ;

        void OnEnable()

        {
            isEnabled = serializedObject.FindProperty("isEnabled");
            ActionStatus = serializedObject.FindProperty("ActionStatus");
            SkillButton = serializedObject.FindProperty("SkillButton");
            usingShortcut = serializedObject.FindProperty("usingShortcut");
            Shortcut = serializedObject.FindProperty("Shortcut");
            usingCooldown = serializedObject.FindProperty("usingCooldown");
            CooldownTimer = serializedObject.FindProperty("CooldownTimer");
            CooldownText = serializedObject.FindProperty("CooldownText");
            usingMana = serializedObject.FindProperty("usingMana");
            TargetMana = serializedObject.FindProperty("TargetMana");
            ManaCost = serializedObject.FindProperty("ManaCost");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(isEnabled);
            if (isEnabled.boolValue)
            {
                EditorGUILayout.PropertyField(ActionStatus, true);
                if (ActionStatus.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(SkillButton, true);
                if (SkillButton.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }
                EditorGUILayout.PropertyField(usingShortcut, true);
                if (usingShortcut.boolValue)
                {
                    EditorGUILayout.PropertyField(Shortcut, true);
                }
                EditorGUILayout.PropertyField(usingCooldown, true);
                if (usingCooldown.boolValue)
                {
                    EditorGUILayout.PropertyField(CooldownTimer, true);
                    EditorGUILayout.PropertyField(CooldownText, true);
                }
                EditorGUILayout.PropertyField(usingMana, true);
                if (usingMana.boolValue)
                {
                    EditorGUILayout.PropertyField(TargetMana, true);
                    EditorGUILayout.PropertyField(ManaCost, true);
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