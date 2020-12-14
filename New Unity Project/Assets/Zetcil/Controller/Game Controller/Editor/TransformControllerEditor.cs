using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Zetcil
{
    [CustomEditor(typeof(TransformController)), CanEditMultipleObjects]
    public class TransformControllerEditor : Editor
    {
        public SerializedProperty
            isEnabled,
            TargetObject,
            InvokeType,
            usingPosition,
            PositionValue,
            usingRotation,
            RotationValue,
            usingScale,
            ScaleValue,
            usingTranslate,
            TranslateValue,
            TranslateSpeed,
            usingPingPong,
            PingPongValue,
            PingPongSpeed,
            usingPingPongDirection,
            Distance,
            StartDirection,
            EndDirection,
            usingAdditionalSettings,
            AdditionalSettings,

            //--Invoke type (1)
            usingDelay,
            Delay,
            usingInterval,
            Interval
        ;

        void OnEnable()
        {
            // Setup the SerializedProperties
            isEnabled = serializedObject.FindProperty("isEnabled");
            TargetObject = serializedObject.FindProperty("TargetObject");
            InvokeType = serializedObject.FindProperty("InvokeType");
            usingPosition = serializedObject.FindProperty("usingPosition");
            PositionValue = serializedObject.FindProperty("PositionValue");
            usingRotation = serializedObject.FindProperty("usingRotation");
            RotationValue = serializedObject.FindProperty("RotationValue");
            usingScale = serializedObject.FindProperty("usingScale");
            ScaleValue = serializedObject.FindProperty("ScaleValue");
            usingTranslate = serializedObject.FindProperty("usingTranslate");
            TranslateValue = serializedObject.FindProperty("TranslateValue");
            TranslateSpeed = serializedObject.FindProperty("TranslateSpeed");
            usingPingPong = serializedObject.FindProperty("usingPingPong");
            PingPongValue = serializedObject.FindProperty("PingPongValue");
            PingPongSpeed = serializedObject.FindProperty("PingPongSpeed");

            usingPingPongDirection = serializedObject.FindProperty("usingPingPongDirection");
            Distance = serializedObject.FindProperty("Distance");
            StartDirection = serializedObject.FindProperty("StartDirection");
            EndDirection = serializedObject.FindProperty("EndDirection");

            usingAdditionalSettings = serializedObject.FindProperty("usingAdditionalSettings");
            AdditionalSettings = serializedObject.FindProperty("AdditionalSettings");

            //--Invoke type (2)
            usingDelay = serializedObject.FindProperty("usingDelay");
            Delay = serializedObject.FindProperty("Delay");
            usingInterval = serializedObject.FindProperty("usingInterval");
            Interval = serializedObject.FindProperty("Interval");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(isEnabled);

            GlobalVariable.CInvokeType st = (GlobalVariable.CInvokeType) InvokeType.enumValueIndex;

            bool check = isEnabled.boolValue;

            if (check)
            {
                EditorGUILayout.PropertyField(TargetObject, true);
                EditorGUILayout.PropertyField(InvokeType, true);

                EditorGUILayout.PropertyField(usingPosition, true);
                if (usingPosition.boolValue)
                {
                        EditorGUILayout.PropertyField(PositionValue, true);
                }

                EditorGUILayout.PropertyField(usingRotation, true);
                if (usingRotation.boolValue)
                {
                        EditorGUILayout.PropertyField(RotationValue, true);
                }

                EditorGUILayout.PropertyField(usingScale, true);
                if (usingScale.boolValue)
                {
                        EditorGUILayout.PropertyField(ScaleValue, true);
                }

                EditorGUILayout.PropertyField(usingTranslate, true);
                if (usingTranslate.boolValue)
                {
                        EditorGUILayout.PropertyField(TranslateSpeed, true);
                        EditorGUILayout.PropertyField(TranslateValue, true);
                }

                EditorGUILayout.PropertyField(usingPingPong, true);
                if (usingPingPong.boolValue)
                {
                        EditorGUILayout.PropertyField(PingPongValue, true);
                        EditorGUILayout.PropertyField(PingPongSpeed, true);
                }

                EditorGUILayout.PropertyField(usingPingPongDirection, true);
                if (usingPingPongDirection.boolValue)
                {
                    EditorGUILayout.PropertyField(Distance, true);
                    EditorGUILayout.PropertyField(StartDirection, true);
                    EditorGUILayout.PropertyField(EndDirection, true);
                }

                EditorGUILayout.PropertyField(usingAdditionalSettings, true);
                if (usingAdditionalSettings.boolValue)
                {
                    EditorGUILayout.PropertyField(AdditionalSettings, true);
                }



                //--Invoke type (3)
                if ((GlobalVariable.CInvokeType)InvokeType.enumValueIndex == GlobalVariable.CInvokeType.OnDelay)
                {
                    EditorGUILayout.PropertyField(usingDelay, true);
                    if (usingDelay.boolValue)
                    {
                        EditorGUILayout.PropertyField(Delay, true);
                    }
                }
                if ((GlobalVariable.CInvokeType)InvokeType.enumValueIndex == GlobalVariable.CInvokeType.OnInterval)
                {
                    EditorGUILayout.PropertyField(usingInterval, true);
                    if (usingInterval.boolValue)
                    {
                        EditorGUILayout.PropertyField(Interval, true);
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
