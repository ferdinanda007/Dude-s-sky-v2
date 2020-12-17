using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Zetcil
{
    [CustomEditor(typeof(LegacyController)), CanEditMultipleObjects]
    public class LegacyControllerEditor : Editor
    {
        public SerializedProperty
            isEnabled,
            TargetAnimator,
            EventType,
            usingStaticAnimationName,
            StaticAnimationName,
            ParameterKey,
            usingKeyDown,
            KeyDownEvent,
            usingKeyPress,
            KeyPressEvent,
            usingKeyUp,
            KeyUpEvent,
            usingAdditionalSettings,
            AdditionalEvent
        ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");
            TargetAnimator = serializedObject.FindProperty("TargetAnimator");
            EventType = serializedObject.FindProperty("EventType");
            usingStaticAnimationName = serializedObject.FindProperty("usingStaticAnimationName");
            StaticAnimationName = serializedObject.FindProperty("StaticAnimationName");
            ParameterKey = serializedObject.FindProperty("ParameterKey");
            usingKeyDown = serializedObject.FindProperty("usingKeyDown");
            KeyDownEvent = serializedObject.FindProperty("KeyDownEvent");
            usingKeyPress = serializedObject.FindProperty("usingKeyPress");
            KeyPressEvent = serializedObject.FindProperty("KeyPressEvent");
            usingKeyUp = serializedObject.FindProperty("usingKeyUp");
            KeyUpEvent = serializedObject.FindProperty("KeyUpEvent");
            usingAdditionalSettings = serializedObject.FindProperty("usingAdditionalSettings");
            AdditionalEvent = serializedObject.FindProperty("AdditionalEvent");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            LegacyController.CEventType st = (LegacyController.CEventType)EventType.enumValueIndex;

            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(TargetAnimator, true);
                if (TargetAnimator.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(EventType, true);

                if (st == LegacyController.CEventType.OnAwake ||
                    st == LegacyController.CEventType.OnEvent ||
                    st == LegacyController.CEventType.OnRepeat)
                {
                    EditorGUILayout.PropertyField(usingStaticAnimationName, true);
                    EditorGUILayout.PropertyField(StaticAnimationName, true);

                    EditorGUILayout.PropertyField(usingAdditionalSettings, true);
                    if (usingAdditionalSettings.boolValue)
                    {
                        EditorGUILayout.PropertyField(AdditionalEvent, true);
                    }
                }
                if (st == LegacyController.CEventType.OnKeyboard)
                {
                    EditorGUILayout.PropertyField(usingStaticAnimationName, true);
                    EditorGUILayout.PropertyField(StaticAnimationName, true);

                    EditorGUILayout.PropertyField(ParameterKey, true);
                    EditorGUILayout.PropertyField(usingKeyDown, true);
                    if (usingKeyDown.boolValue)
                    {
                        EditorGUILayout.PropertyField(KeyDownEvent, true);
                    }
                    EditorGUILayout.PropertyField(usingKeyPress, true);
                    if (usingKeyPress.boolValue)
                    {
                        EditorGUILayout.PropertyField(KeyPressEvent, true);
                    }
                    EditorGUILayout.PropertyField(usingKeyUp, true);
                    if (usingKeyUp.boolValue)
                    {
                        EditorGUILayout.PropertyField(KeyUpEvent, true);
                    }

                    EditorGUILayout.PropertyField(usingAdditionalSettings, true);
                    if (usingAdditionalSettings.boolValue)
                    {
                        EditorGUILayout.PropertyField(AdditionalEvent, true);
                    }
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
