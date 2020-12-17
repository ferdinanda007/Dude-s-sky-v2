using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Zetcil
{
    [CustomEditor(typeof(MecanimController)), CanEditMultipleObjects]
    public class MecanimControllerEditor : Editor
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
            usingIdle,
            IdleEvent,
            usingMoving,
            MovingEvent,
            usingCustomEvent,
            CustomEvent,
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

            usingIdle = serializedObject.FindProperty("usingIdle");
            IdleEvent = serializedObject.FindProperty("IdleEvent");
            usingMoving = serializedObject.FindProperty("usingMoving");
            MovingEvent = serializedObject.FindProperty("MovingEvent");
            usingCustomEvent = serializedObject.FindProperty("usingCustomEvent");
            CustomEvent = serializedObject.FindProperty("CustomEvent");

            usingAdditionalSettings = serializedObject.FindProperty("usingAdditionalSettings");
            AdditionalEvent = serializedObject.FindProperty("AdditionalEvent");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            MecanimController.CEventType st = (MecanimController.CEventType)EventType.enumValueIndex;

            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(TargetAnimator, true);
                if (TargetAnimator.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Required Field(s) Null / None", MessageType.Error);
                }

                EditorGUILayout.PropertyField(EventType, true);

                if (st == MecanimController.CEventType.OnAwake ||
                    st == MecanimController.CEventType.OnRepeat)
                {
                    EditorGUILayout.PropertyField(ParameterType, true);
                    EditorGUILayout.PropertyField(ParameterName, true);

                    MecanimController.CParameterType pt = (MecanimController.CParameterType)ParameterType.enumValueIndex;
                    if (pt == MecanimController.CParameterType.Int)
                    {
                        EditorGUILayout.PropertyField(ParameterInteger, true);
                    }
                    if (pt == MecanimController.CParameterType.Float)
                    {
                        EditorGUILayout.PropertyField(ParameterFloat, true);
                    }
                    if (pt == MecanimController.CParameterType.Bool)
                    {
                        EditorGUILayout.PropertyField(ParameterBoolean, true);
                    }
                    if (pt == MecanimController.CParameterType.Trigger)
                    {
                        EditorGUILayout.PropertyField(ParameterTrigger, true);
                    }

                    EditorGUILayout.PropertyField(usingAdditionalSettings, true);
                    if (usingAdditionalSettings.boolValue)
                    {
                        EditorGUILayout.PropertyField(AdditionalEvent, true);
                    }
                }
                else if (st == MecanimController.CEventType.OnKeyboard)
                {
                    EditorGUILayout.PropertyField(ParameterType, true);
                    EditorGUILayout.PropertyField(ParameterName, true);
                    MecanimController.CParameterType pt = (MecanimController.CParameterType)ParameterType.enumValueIndex;
                    if (pt == MecanimController.CParameterType.Int)
                    {
                        EditorGUILayout.PropertyField(ParameterInteger, true);
                    }
                    if (pt == MecanimController.CParameterType.Float)
                    {
                        EditorGUILayout.PropertyField(ParameterFloat, true);
                    }
                    if (pt == MecanimController.CParameterType.Bool)
                    {
                        EditorGUILayout.PropertyField(ParameterBoolean, true);
                    }
                    if (pt == MecanimController.CParameterType.Trigger)
                    {
                        EditorGUILayout.PropertyField(ParameterTrigger, true);
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
            else if (st == MecanimController.CEventType.OnVelocity)
            {
                EditorGUILayout.PropertyField(ParameterType, true);
                EditorGUILayout.PropertyField(ParameterName, true);
                MecanimController.CParameterType pt = (MecanimController.CParameterType)ParameterType.enumValueIndex;
                if (pt == MecanimController.CParameterType.Int)
                {
                    EditorGUILayout.PropertyField(ParameterInteger, true);
                }
                if (pt == MecanimController.CParameterType.Float)
                {
                    EditorGUILayout.PropertyField(ParameterFloat, true);
                }
                if (pt == MecanimController.CParameterType.Bool)
                {
                    EditorGUILayout.PropertyField(ParameterBoolean, true);
                }
                if (pt == MecanimController.CParameterType.Trigger)
                {
                    EditorGUILayout.PropertyField(ParameterTrigger, true);
                }

                EditorGUILayout.PropertyField(usingIdle, true);
                if (usingIdle.boolValue)
                {
                    EditorGUILayout.PropertyField(IdleEvent, true);
                }
                EditorGUILayout.PropertyField(usingMoving, true);
                if (usingMoving.boolValue)
                {
                    EditorGUILayout.PropertyField(MovingEvent, true);
                }
                EditorGUILayout.PropertyField(usingAdditionalSettings, true);
                if (usingAdditionalSettings.boolValue)
                {
                    EditorGUILayout.PropertyField(AdditionalEvent, true);
                }
            }
            else if (st == MecanimController.CEventType.OnEvent)
            {
                EditorGUILayout.PropertyField(ParameterType, true);
                EditorGUILayout.PropertyField(ParameterName, true);
                MecanimController.CParameterType pt = (MecanimController.CParameterType)ParameterType.enumValueIndex;
                if (pt == MecanimController.CParameterType.Int)
                {
                    EditorGUILayout.PropertyField(ParameterInteger, true);
                }
                if (pt == MecanimController.CParameterType.Float)
                {
                    EditorGUILayout.PropertyField(ParameterFloat, true);
                }
                if (pt == MecanimController.CParameterType.Bool)
                {
                    EditorGUILayout.PropertyField(ParameterBoolean, true);
                }
                if (pt == MecanimController.CParameterType.Trigger)
                {
                    EditorGUILayout.PropertyField(ParameterTrigger, true);
                }

                EditorGUILayout.PropertyField(usingCustomEvent, true);
                if (usingCustomEvent.boolValue)
                {
                    EditorGUILayout.PropertyField(CustomEvent, true);
                }
                EditorGUILayout.PropertyField(usingAdditionalSettings, true);
                if (usingAdditionalSettings.boolValue)
                {
                    EditorGUILayout.PropertyField(AdditionalEvent, true);
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
