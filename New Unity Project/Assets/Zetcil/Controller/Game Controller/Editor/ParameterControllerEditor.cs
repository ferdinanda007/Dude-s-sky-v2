using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Zetcil
{
    [CustomEditor(typeof(ParameterController)), CanEditMultipleObjects]
    public class ParameterControllerEditor : Editor
    {
        public SerializedProperty
            isEnabled,
            TargetAnimator,
            EventType,
            ParameterType,
            ParameterName,
            ParameterFloat,
            ParameterInteger,
            ParameterBoolean,
            ParameterTrigger,
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
            ParameterType = serializedObject.FindProperty("ParameterType");
            ParameterName = serializedObject.FindProperty("ParameterName");
            ParameterFloat = serializedObject.FindProperty("ParameterFloat");
            ParameterInteger = serializedObject.FindProperty("ParameterInteger");
            ParameterBoolean = serializedObject.FindProperty("ParameterBoolean");
            ParameterTrigger = serializedObject.FindProperty("ParameterTrigger");
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

            ParameterController.CEventType st = (ParameterController.CEventType) EventType.enumValueIndex;

            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(TargetAnimator, true);
                if (TargetAnimator.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(EventType, true);

                if (st == ParameterController.CEventType.OnAwake ||
                    st == ParameterController.CEventType.OnEvent ||
                    st == ParameterController.CEventType.OnRepeat)
                {
                    EditorGUILayout.PropertyField(ParameterType, true);
                    EditorGUILayout.PropertyField(ParameterName, true);

                    ParameterController.CParameterType pt = (ParameterController.CParameterType) ParameterType.enumValueIndex;
                    if (pt == ParameterController.CParameterType.Int)
                    {
                        EditorGUILayout.PropertyField(ParameterInteger, true);
                        if (ParameterInteger.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }
                    if (pt == ParameterController.CParameterType.Float)
                    {
                        EditorGUILayout.PropertyField(ParameterFloat, true);
                        if (ParameterFloat.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }
                    if (pt == ParameterController.CParameterType.Bool)
                    {
                        EditorGUILayout.PropertyField(ParameterBoolean, true);
                        if (ParameterBoolean.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }
                    if (pt == ParameterController.CParameterType.Trigger)
                    {
                        EditorGUILayout.PropertyField(ParameterTrigger, true);
                        if (ParameterTrigger.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }

                    EditorGUILayout.PropertyField(usingAdditionalSettings, true);
                    if (usingAdditionalSettings.boolValue)
                    {
                        EditorGUILayout.PropertyField(AdditionalEvent, true);
                    }
                }
                if (st == ParameterController.CEventType.OnKeyboard)
                {
                    EditorGUILayout.PropertyField(ParameterType, true);
                    EditorGUILayout.PropertyField(ParameterName, true);
                    ParameterController.CParameterType pt = (ParameterController.CParameterType)ParameterType.enumValueIndex;
                    if (pt == ParameterController.CParameterType.Int)
                    {
                        EditorGUILayout.PropertyField(ParameterInteger, true);
                        if (ParameterInteger.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }
                    if (pt == ParameterController.CParameterType.Float)
                    {
                        EditorGUILayout.PropertyField(ParameterFloat, true);
                        if (ParameterFloat.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }
                    if (pt == ParameterController.CParameterType.Bool)
                    {
                        EditorGUILayout.PropertyField(ParameterBoolean, true);
                        if (ParameterBoolean.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }
                    if (pt == ParameterController.CParameterType.Trigger)
                    {
                        EditorGUILayout.PropertyField(ParameterTrigger, true);
                        if (ParameterTrigger.objectReferenceValue == null)
                        {
                            EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                        }
                    }

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
