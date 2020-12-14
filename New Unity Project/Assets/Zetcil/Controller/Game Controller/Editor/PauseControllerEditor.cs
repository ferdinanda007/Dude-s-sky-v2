using UnityEditor;
using UnityEngine;

namespace Zetcil
{
    [CustomEditor(typeof(PauseController)), CanEditMultipleObjects]
    public class PauseControllerEditor : Editor
    {

        public SerializedProperty
            isEnabled,
            PauseType,
            GameStatus,
            TriggerKey,
            usingPlayCondition,
            PlayCondition,
            usingPauseCondition,
            PauseCondition,
            TargetObject,
            TargetAudio
            ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");
            PauseType = serializedObject.FindProperty("PauseType");
            GameStatus = serializedObject.FindProperty("GameStatus");
            TriggerKey = serializedObject.FindProperty("TriggerKey");
            usingPlayCondition = serializedObject.FindProperty("usingPlayCondition");
            PlayCondition = serializedObject.FindProperty("PlayCondition");
            usingPauseCondition = serializedObject.FindProperty("usingPauseCondition");
            PauseCondition = serializedObject.FindProperty("PauseCondition");
            TargetObject = serializedObject.FindProperty("TargetObject");
            TargetAudio = serializedObject.FindProperty("TargetAudio");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(PauseType);
                EditorGUILayout.PropertyField(GameStatus);
                EditorGUILayout.PropertyField(TriggerKey);

                bool check1 = usingPlayCondition.boolValue;
                bool check2 = usingPauseCondition.boolValue;

                EditorGUILayout.PropertyField(usingPauseCondition);

                if (check2)
                {
                    EditorGUILayout.PropertyField(PauseCondition, true);
                }

                EditorGUILayout.PropertyField(usingPlayCondition, true);

                if (check1)
                {
                    EditorGUILayout.PropertyField(PlayCondition, true);
                }

                
                if ((PauseController.CPauseType) PauseType.enumValueIndex == PauseController.CPauseType.GameObject)
                {
                    EditorGUILayout.PropertyField(TargetAudio, true);
                    EditorGUILayout.PropertyField(TargetObject, true);
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